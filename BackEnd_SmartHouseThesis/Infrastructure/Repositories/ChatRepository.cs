using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ChatRepository : BaseRepo<Chat>
    {
        private readonly AppDbContext _appDbContext;
        private readonly AccountRepository _accountRepository;
        public ChatRepository(AppDbContext dbContext, AccountRepository accountRepository) : base(dbContext)
        {
            _appDbContext = dbContext;
            _accountRepository = accountRepository;
        }
        public async Task SaveChatLog(string chatMessage, Guid senderId, Guid receiverId)
        {
            var sender = await _accountRepository.GetAsync(senderId);
            var receiver = await _accountRepository.GetAsync(receiverId);
            if (sender.Role.RoleName == "Teller")
            {
                var chatLog = new Chat
                {
                    // Save the chat log to the database
                    TellerId = senderId,
                    CustomerId = receiverId,
                    CreationDate = DateTime.Now,
                    Logchat = $"{DateTime.Now} - {sender.FirstName + " " + sender.LastName}: {chatMessage}"
                };
                _appDbContext.Chats.Add(chatLog);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                var chatLog = new Chat
                {
                    // Save the chat log to the database
                    CustomerId = senderId,
                    TellerId = receiverId,
                    CreationDate = DateTime.Now,
                    Logchat = $"{DateTime.Now} - {sender}: {chatMessage}"
                };
                _appDbContext.Chats.Add(chatLog);
                await _appDbContext.SaveChangesAsync();
            }
        }
        public async Task<List<Chat>> GetChatLogs(Guid senderId, Guid receiverId)
        {
            List<Chat> chatLists = await _appDbContext.Chats.Where(c => (c.Customer.Id == senderId && c.Teller.Id == receiverId) || (c.Teller.Id == senderId && c.Customer.Id == receiverId)).OrderBy(c => c.CreationDate).ToListAsync();
            return chatLists;
        }
    }
}
