using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Sercurity
{
    public class PasswordHash
    {

        private readonly RoleService _roleService;
        public PasswordHash (RoleService roleService)
        {
            _roleService = roleService;
        }

        public string HashPassword(string password)
        {
            // Generate a salt
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash the password with the salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        // Function to verify a password
        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the password against the hashed password
            bool result = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return result;
        }

        public string GenerateJwtToken(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SS590Z/hUu8cjD9w4W51xA==")); // fix cứng chưa verify với construct                             
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // lấy role từ role Id 
            var role = _roleService.GetRole(account.RoleId);
            var claims = new List<Claim>
     {
         new Claim(ClaimTypes.Name, account.FirstName), // tên 
         new Claim(ClaimTypes.GivenName, account.LastName), //tên chính thức 
         new Claim(ClaimTypes.Email, account.Email), // email
         new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()), // Thêm ID người dùng vào claim
         new Claim(ClaimTypes.Role, role.Result.RoleName),// Sử dụng RoleName từ bảng Role
         new Claim(ClaimTypes.StreetAddress, account.Address)
     };
            var token = new JwtSecurityToken(
                issuer: "ISHE",
                audience: "ISHE",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /*
                public static string Encrypt(string password, string secrectKey)
                {
                    string EncryptionKey = secrectKey;
                    byte[] clearBytes = Encoding.Unicode.GetBytes(password);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(clearBytes, 0, clearBytes.Length);
                                cs.Close();
                            }
                            password = Convert.ToBase64String(ms.ToArray());
                        }
                    }
                    return password;
                }

                public static string Decrypt(string cipherText, string secrectKey)
                {
                    string EncryptionKey = secrectKey;
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.Close();
                            }
                            cipherText = Encoding.Unicode.GetString(ms.ToArray());
                        }
                    }
                    return cipherText;
                }*/
    }
}
