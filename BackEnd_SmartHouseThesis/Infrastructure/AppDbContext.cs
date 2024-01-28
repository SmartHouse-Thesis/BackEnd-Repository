using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Acceptance> Acceptances { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Device> Device { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<Image> Image { get; set; } = null!;
        public DbSet<Owner> Owner { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        public DbSet<Payment> Payment { get; set; } = null!;
        public DbSet<Promotion> Promotion { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<Revenue> Revenues { get; set; } = null!;
        public DbSet<Role> Role { get; set; } = null!;
        public DbSet<Staff> Staff { get; set; } = null!;
        public DbSet<Survey> Surveys { get; set; } = null!;
        public DbSet<Teller> Tellers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=SmartHome;User ID=sa;Password=12345");
            }*/
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration
                        .GetConnectionString("SmartHomeDB");

            optionsBuilder.UseSqlServer(connectionString);
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //funcion Seeding Data;
            AddData(modelBuilder);
            

            // one-to-one 
            //Account - Cus,Owner,Staff,Teller
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Account)
                 .WithOne(a => a.Customer)         
                .HasForeignKey<Customer>(c => c.Id);

            modelBuilder.Entity<Owner>()
                .HasOne(o => o.Account)
                 .WithOne(a => a.Owner)
                .HasForeignKey<Owner>(o => o.Id);

            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Account)
                 .WithOne(a => a.Staff)
                .HasForeignKey<Staff>(s => s.Id);

            modelBuilder.Entity<Teller>()
                .HasOne(t => t.Account)
                 .WithOne(a => a.Teller)
                .HasForeignKey<Teller>(t => t.Id);

            //Survey-Request
            modelBuilder.Entity<Survey>()
                .HasOne(s => s.Request)
                 .WithOne(r => r.Survey)
                .HasForeignKey<Survey>(c => c.RequestId);

            modelBuilder.Entity<Request>()
               .HasOne(s => s.Survey)
                .WithOne(r => r.Request)
               .HasForeignKey<Request>(c => c.SurveyId);

            //Constract-Acceptance
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Acceptance)
                 .WithOne(a => a.Contract)
                .HasForeignKey<Contract>(c => c.AcceptanceId);

            modelBuilder.Entity<Acceptance>()
               .HasOne(a => a.Contract)
                .WithOne(c => c.Acceptance)
               .HasForeignKey<Acceptance>(c => c.ContractId);

            //Package-Image
            modelBuilder.Entity<Package>()
                   .HasOne(p => p.Image)
                   .WithOne(i => i.Package)
                   .HasForeignKey<Package>(c => c.ImageId);

            modelBuilder.Entity<Image>()
                .HasOne(i=>i.Package)
                .WithOne(p=>p.Image)
                .HasForeignKey<Image>(c => c.PackageId);

            //Order-OrderDetail
            modelBuilder.Entity<OrderDetail>()
               .HasOne(o => o.Order)
                .WithOne(a => a.OrderDetail)
               .HasForeignKey<OrderDetail>(o => o.Id);

            //Packge - Manufacturer 
            modelBuilder.Entity<Package>()
                   .HasOne(p => p.Manufacturer)
                   .WithOne(i => i.Package)
                   .HasForeignKey<Package>(c => c.ManufacturerId);

            modelBuilder.Entity<Manufacturer>()
                .HasOne(i => i.Package)
                .WithOne(p => p.Manufacturer)
                .HasForeignKey<Manufacturer>(c => c.PackageId);

            //Packge - Policy 
            modelBuilder.Entity<Package>()
                   .HasOne(p => p.Policy)
                   .WithOne(i => i.Package)
                   .HasForeignKey<Package>(c => c.PolicyId);

            modelBuilder.Entity<Policy>()
                .HasOne(i => i.Package)
                .WithOne(p => p.Policy)
                .HasForeignKey<Policy>(c => c.PackageId);

            //Acceptance-WarrantyReport
            /* 
            modelBuilder.Entity<Acceptance>()
                .HasOne(a => a.WarrantyReport)
                .WithOne(w => w.Acceptance)
                .HasForeignKey<Acceptance>(c => c.WarrantyId);

            modelBuilder.Entity<WarrantyReport>()
                .HasOne(w => w.Acceptance)
                .WithOne(a => a.WarrantyReport)
                .HasForeignKey<WarrantyReport>(c => c.AcceptanceId);*/

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }



        //Hàm Thêm DATA
        private void AddData(ModelBuilder builder)
        {
            // biến id cho 4 role
            var RoleId = new Dictionary<string, Guid>
               {
                    { "Owner", Guid.NewGuid() },
                    { "Staff", Guid.NewGuid() },
                    {"Teller", Guid.NewGuid() },
                    {"Customer", Guid.NewGuid()}
                    
                };

            builder.Entity<Role>().HasData(
                new Role { Id = RoleId["Owner"], RoleName = "Owner" },
                new Role { Id = RoleId["Staff"], RoleName = "Staff" },
                new Role { Id = RoleId["Teller"], RoleName = "Teller" },
                new Role { Id = RoleId["Customer"], RoleName = "Customer" }
                );
           
            //biến ID Account 
           Guid customerId = Guid.NewGuid();
           Guid tellerId = Guid.NewGuid();
           Guid ownerId = Guid.NewGuid();
           Guid staffLeadId = Guid.NewGuid();
           Guid staffId1 = Guid.NewGuid();
           Guid staffId2 = Guid.NewGuid();

            //AccountData
            builder.Entity<Account>().HasData(
                new Account { Id = ownerId, Address="Owner Address", Email="Owner@gmail.com", Password="owner", FirstName="Owner", LastName="Account", CreationDate= DateTime.Now, RoleId = RoleId["Owner"] },
                new Account { Id = tellerId, Address = "Teller Address", Email = "Teller@gmail.com", Password = "teller", FirstName = "Teller", LastName = "Account", CreationDate = DateTime.Now, RoleId = RoleId["Teller"] },
                new Account { Id = customerId, Address = "Customer Address", Email = "Customer@gmail.com", Password = "customer", FirstName = "Customer", LastName = "Account", CreationDate = DateTime.Now, RoleId = RoleId["Customer"] },
                new Account { Id = staffLeadId, Address = "Staff Lead Address", Email = "StaffLead@gmail.com", Password = "stafflead", FirstName = "Staff Lead", LastName = "Account", CreationDate = DateTime.Now, RoleId = RoleId["Staff"] },
                new Account { Id = staffId1, Address = "Staff 1 Address", Email = "Staff1@gmail.com", Password = "staff1", FirstName = "Staff 1", LastName = "Account", CreationDate = DateTime.Now, RoleId = RoleId["Staff"] },
                new Account { Id = staffId2, Address = "Staff 2 Address", Email = "Staff2@gmail.com", Password = "staff2", FirstName = "Staff 2", LastName = "Account", CreationDate = DateTime.Now, RoleId = RoleId["Staff"] }
                );
            //OnwerData
            builder.Entity<Owner>().HasData(
                new Owner { Id= ownerId}
                );
            //TellerData
            builder.Entity<Teller>().HasData(
               new Teller { Id = tellerId }
               );
            //CustomerData
            builder.Entity<Customer>().HasData(
               new Customer { Id = customerId }
               );
            //Staff
            builder.Entity<Staff>().HasData(
               new Staff { Id = staffLeadId },
               new Staff { Id = staffId1 },
               new Staff { Id = staffId2}
               );

            //bien id cho Manufacture
            Guid IdManu1 = Guid.NewGuid();
            Guid IdManu2 = Guid.NewGuid();
            Guid IdManu3 = Guid.NewGuid();
            Guid IdManu4 = Guid.NewGuid();
            Guid IdManu5 = Guid.NewGuid();
            Guid IdManu6 = Guid.NewGuid();
            Guid IdManu7 = Guid.NewGuid();
            Guid IdManu8 = Guid.NewGuid();
            Guid IdManu9 = Guid.NewGuid();

            //Manufacturer Data
            builder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = IdManu1, Name = "Xiaomi" },
                new Manufacturer { Id = IdManu2, Name = "Google" },
                new Manufacturer { Id = IdManu3, Name = "Nest " },
                new Manufacturer { Id = IdManu4, Name = "Philip" },
                new Manufacturer { Id = IdManu5, Name = "LG" },
                new Manufacturer { Id = IdManu6, Name = "Philip" },
                new Manufacturer { Id = IdManu7, Name = "BKAV" },
                new Manufacturer { Id = IdManu8, Name = "Vsmart" },
                new Manufacturer { Id = IdManu9, Name = "Javis" }
                );
            //biến Id của package
            Guid PackageId1 = Guid.NewGuid();
            Guid PackageId2 = Guid.NewGuid();
            /*
                        var PackgeList = new List<Package>
                        {          
                            new Package { Id=PackageId1, PackageName= "Bộ Thiết Bị Nhà Thông Minh Xiaomi Smart Home Security Kit 5 Trong 1", Description= "Mi Home hỗ trợ rất nhiều thiết bị nhà thông minh như: camera, máy lọc không khí, quạt điện, robot hút bụi … được kết nối và điều khiển qua ứng dụng.\r\n\r\nTùy vào từng hoàn cảnh mà người dùng có thể dễ dàng điều khiển tự động như: đèn sáng, quạt quay, robot hoạt động … Điều này giúp bạn không cần phải tự động phải ở gần thiết bị mới làm được.\r\n\r\nHiểu được điều này, Xiaomi đã cho ra mắt bộ thiết bị nhà thông mình Xiaomi Smart Home Security Kit 5 Trong 1. Sản phẩm bao gồm:\r\n\r\nBộ điều khiển trung tâm;\r\nCảm biến chuyển động;\r\nCảm biến đóng / mở cửa;\r\nChuông cửa;\r\nỔ cắm thông minh.", Price =1490000},
                            new Package { Id=PackageId2, PackageName ="Gói Sản Phẩm Nhà thông Minh BKAV", Description="",Price= 105450000 }
                        };*/

            //Package Data
            builder.Entity<Package>().HasData(
                new Package { Id = PackageId1, PackageName = "Bộ Thiết Bị Nhà Thông Minh Xiaomi Smart Home Security Kit 5 Trong 1", Description = "Mi Home hỗ trợ rất nhiều thiết bị nhà thông minh như: camera, máy lọc không khí, quạt điện, robot hút bụi … được kết nối và điều khiển qua ứng dụng.\r\n\r\nTùy vào từng hoàn cảnh mà người dùng có thể dễ dàng điều khiển tự động như: đèn sáng, quạt quay, robot hoạt động … Điều này giúp bạn không cần phải tự động phải ở gần thiết bị mới làm được.\r\n\r\nHiểu được điều này, Xiaomi đã cho ra mắt bộ thiết bị nhà thông mình Xiaomi Smart Home Security Kit 5 Trong 1. Sản phẩm bao gồm:\r\n\r\nBộ điều khiển trung tâm;\r\nCảm biến chuyển động;\r\nCảm biến đóng / mở cửa;\r\nChuông cửa;\r\nỔ cắm thông minh.", Price = 1490000 },
                new Package { Id = PackageId2, PackageName = "Gói Sản Phẩm Nhà thông Minh BKAV", Description = "", Price = 105000000 }
                );

            //bien id cho Device
            Guid IdDevice1 = Guid.NewGuid();
            Guid IdDevice2 = Guid.NewGuid();
            Guid IdDevice3 = Guid.NewGuid();
            Guid IdDevice4 = Guid.NewGuid();
            Guid IdDevice5 = Guid.NewGuid();
            Guid IdDevice6 = Guid.NewGuid();
            Guid IdDevice7 = Guid.NewGuid();
            Guid IdDevice8 = Guid.NewGuid();
            Guid IdDevice9 = Guid.NewGuid();
            Guid IdDevice10 = Guid.NewGuid();
            Guid IdDevice11 = Guid.NewGuid();

            /*
                        var DeviceList = new List<Device>
                {
                    //xiaomi
                              new Device { Id = IdDevice1, DeviceName = "Xiaomi Smart Home Gateway", Description = "Nếu là tín đồ của các thiết bị ngôi nhà thông minh Xiaomi thì bộ điều khiển trung tâm Homekit Xiaomi Gateway V3 sẽ là lựa chọn mà bạn không thể bỏ qua. Thiết bị giúp bạn có thể điều khiển các thiết bị trong bộ Homekit với kết nối ổn định, nhanh chóng và đặc biệt là bảo mật quyền riêng tư tốt.", Price = 800000, DeviceType = "Gateway", ManufacturerId = IdManu1, Packages = PackgeList[0]},
                            new Device { Id = IdDevice2, DeviceName = "Cảm biến gắn cửa Xiaomi 2 MCCGQ02HL", Description = "thiết bị giúp theo dõi và thông báo trạng thái đóng, mở cửa cho ngôi nhà của bạn một cách nhanh chóng và chính xác theo thời gian thực. Sản phẩm là một thiết bị không thể bỏ qua nếu người dùng mong muốn xây dựng nhà thông minh.", Price = 180000, DeviceType = "Sensor", ManufacturerId = IdManu1 },
                            new Device { Id = IdDevice3, DeviceName = "Chuông cửa thông minh Xiaomi Linptech G6L-Wifi-SW", Description = "Nếu gia đình bạn thường xuyên có khách đến thăm hoặc để tránh trường hợp những tên trộm có thủ thuật tinh vi để xâm nhập vào nhà bạn thì việc trang bị Chuông cửa thông minh Xiaomi Linptech G6L-Wifi-SW sẽ là sự bảo vệ hợp lý và hiệu quả nhất.", Price = 399000, DeviceType = "Sensor", ManufacturerId = IdManu1 },
                            new Device { Id = IdDevice4, DeviceName = "Ổ cắm thông minh – Zigbee", Description = "Thiết bị được kết nối qua ứng dụng Mi Home, có thế sử dụng với các thiết bị khác. Một trong những tính năng tôi ưu nhất là điều khiển chức năng của phích cắm tắt/bật từ xa.\r\n\r\nBạn cũng có thể đặt hẹn giờ tắt/bật cho từng ổ cắm. Điều này giúp cho bạn thuận tiện hơn trong khi sử dụng các sản phẩm không phải đồ thông minh khác mà muốn điều khiển từ xa.", Price = 255000, DeviceType = "Electronic", ManufacturerId = IdManu1 },
                            new Device { Id = IdDevice5, DeviceName = "Cảm biến người, chuyển động Xiaomi gen 2 RTCGQ02LM", Description = "Xiaomi gen 2 RTCGQ02LM phiên bản cảm biến chuyển động thế hệ mới mà người dùng nhà thông minh của Xiaomi không thể bỏ qua. Thiết bị giúp phát hiện chuyển động con người, vật nuôi, ánh sáng,...có độ chính xác cao đồng thời cũng được hỗ trợ liên kết với nhiều thiết bị nhà thông minh khác.", Price = 290000, DeviceType = "Sensor", ManufacturerId = IdManu1 },
                            //BKAV 
                            new Device { Id = IdDevice6, DeviceName = "THIẾT BỊ ĐIỀU KHIỂN TRUNG TÂM SH-HC", Description = "Thiết bị điều khiển trung tâm SH-HC là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", Price = 18000000, DeviceType = "Gateway", ManufacturerId = IdManu7 },
                            new Device { Id = IdDevice7, DeviceName = "Công tắc cảm ứng 6 kênh SH-CC6", Description = "Công tắc Công tắc cảm ứng 6 kênh SH-CC6-Lite là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", Price = 12500000, DeviceType = "Switch", ManufacturerId = IdManu7 },
                            new Device { Id = IdDevice8, DeviceName = "Công tắc 4 kênh SH-CT4Z-T2", Description = "Công tắc 4 kênh SH-CT4Z-LITE là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", Price = 4950000, DeviceType = "Switch", ManufacturerId = IdManu7 },
                            new Device { Id = IdDevice9, DeviceName = "Thiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury", Description = "Thiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury là thiết bị an ninh được sử dụng trong hệ thống nhà thông minh SmartHome, có chức năng thu thập tín hiệu từ các cảm biến an ninh như: hàng rào điện tử, cảm biến vị trí, cảm biến kính vỡ, cảm biến báo khói...\r\n\r\nThiết bị được kết nối với hệ thống thông qua mạng truyền thông không dây ZigBee. Tín hiệu an ninh sau khi thu thập, sẽ được thiết bị chuyển đến hệ thống Server SmartHome để sử lý.\r\n\r\nThiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury hỗ trợ 4 kênh thu thập tín hiệu điểm NC/NO, còi báo động và cung cấp nguồn ra 12VDC-1A cho các cảm biến.", Price = 70000000, DeviceType = "Sensor", ManufacturerId = IdManu7 },
                            new Device { Id = IdDevice10, DeviceName = "Công tắc 1 kênh SH-CT1Z-T2", Description = "Thiết bị SH-CT1Z-T2-PRO là công tắc cảm ứng 1 kênh được sử dụng trong hệ thống nhà thông minh SmartHome, hỗ trợ điều khiển 1 kênh để điều khiển các thiết bị điện.", Price = 4650000, DeviceType = "Switch", ManufacturerId = IdManu7 },
                            //Google 
                              new Device { Id = IdDevice11, DeviceName = "Khóa thông minh Google Nest x Yale Smart Lock", Description = "Google Nest Yale là sản phẩm khóa cửa thông minh của Google Nest và Yale. Sản phẩm thuộc công ty khóa hàng đầu thế giới – Yale. Là một trong những thương hiệu quốc tế lâu đời nhất. Yale là một trong những tên tuổi nổi tiếng và được kính trọng nhất trong ngành công nghiệp khóa. Công ty là một phần đáng tự hào của Habitat for Humanity. Đã cung cấp hơn 700.000 ổ khóa cho các ngôi nhà của Habitat for Humanity. Yale là một phần của Tập đoàn ASSA ABLOY, công ty hàng đầu thế giới về các giải pháp mở cửa.", Price = 6990000, DeviceType = "Sercurity", ManufacturerId = IdManu2 }
                };*/

            //Device Data 
            builder.Entity<Device>().HasData(
                  //xiaomi
                  new Device { Id = IdDevice1, DeviceName = "Xiaomi Smart Home Gateway", Description = "Nếu là tín đồ của các thiết bị ngôi nhà thông minh Xiaomi thì bộ điều khiển trung tâm Homekit Xiaomi Gateway V3 sẽ là lựa chọn mà bạn không thể bỏ qua. Thiết bị giúp bạn có thể điều khiển các thiết bị trong bộ Homekit với kết nối ổn định, nhanh chóng và đặc biệt là bảo mật quyền riêng tư tốt.", Price = 800000, DeviceType = "Gateway", ManufacturerId = IdManu1 },
                new Device { Id = IdDevice2, DeviceName = "Cảm biến gắn cửa Xiaomi 2 MCCGQ02HL", Description = "thiết bị giúp theo dõi và thông báo trạng thái đóng, mở cửa cho ngôi nhà của bạn một cách nhanh chóng và chính xác theo thời gian thực. Sản phẩm là một thiết bị không thể bỏ qua nếu người dùng mong muốn xây dựng nhà thông minh.", Price = 180000, DeviceType = "Sensor", ManufacturerId = IdManu1 },
                new Device { Id = IdDevice3, DeviceName = "Chuông cửa thông minh Xiaomi Linptech G6L-Wifi-SW", Description = "Nếu gia đình bạn thường xuyên có khách đến thăm hoặc để tránh trường hợp những tên trộm có thủ thuật tinh vi để xâm nhập vào nhà bạn thì việc trang bị Chuông cửa thông minh Xiaomi Linptech G6L-Wifi-SW sẽ là sự bảo vệ hợp lý và hiệu quả nhất.", Price = 399000, DeviceType = "Sensor", ManufacturerId = IdManu1 },
                new Device { Id = IdDevice4, DeviceName = "Ổ cắm thông minh – Zigbee", Description = "Thiết bị được kết nối qua ứng dụng Mi Home, có thế sử dụng với các thiết bị khác. Một trong những tính năng tôi ưu nhất là điều khiển chức năng của phích cắm tắt/bật từ xa.\r\n\r\nBạn cũng có thể đặt hẹn giờ tắt/bật cho từng ổ cắm. Điều này giúp cho bạn thuận tiện hơn trong khi sử dụng các sản phẩm không phải đồ thông minh khác mà muốn điều khiển từ xa.", Price = 255000, DeviceType = "Electronic", ManufacturerId = IdManu1 },
                new Device { Id = IdDevice5, DeviceName = "Cảm biến người, chuyển động Xiaomi gen 2 RTCGQ02LM", Description = "Xiaomi gen 2 RTCGQ02LM phiên bản cảm biến chuyển động thế hệ mới mà người dùng nhà thông minh của Xiaomi không thể bỏ qua. Thiết bị giúp phát hiện chuyển động con người, vật nuôi, ánh sáng,...có độ chính xác cao đồng thời cũng được hỗ trợ liên kết với nhiều thiết bị nhà thông minh khác.", Price = 290000, DeviceType = "Sensor", ManufacturerId = IdManu1 },
                //BKAV 
                new Device { Id = IdDevice6, DeviceName = "THIẾT BỊ ĐIỀU KHIỂN TRUNG TÂM SH-HC", Description = "Thiết bị điều khiển trung tâm SH-HC là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", Price = 18000000, DeviceType = "Gateway", ManufacturerId = IdManu7 },
                new Device { Id = IdDevice7, DeviceName = "Công tắc cảm ứng 6 kênh SH-CC6", Description = "Công tắc Công tắc cảm ứng 6 kênh SH-CC6-Lite là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", Price = 12500000, DeviceType = "Switch", ManufacturerId = IdManu7 },
                new Device { Id = IdDevice8, DeviceName = "Công tắc 4 kênh SH-CT4Z-T2", Description = "Công tắc 4 kênh SH-CT4Z-LITE là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", Price = 4950000, DeviceType = "Switch", ManufacturerId = IdManu7 },
                new Device { Id = IdDevice9, DeviceName = "Thiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury", Description = "Thiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury là thiết bị an ninh được sử dụng trong hệ thống nhà thông minh SmartHome, có chức năng thu thập tín hiệu từ các cảm biến an ninh như: hàng rào điện tử, cảm biến vị trí, cảm biến kính vỡ, cảm biến báo khói...\r\n\r\nThiết bị được kết nối với hệ thống thông qua mạng truyền thông không dây ZigBee. Tín hiệu an ninh sau khi thu thập, sẽ được thiết bị chuyển đến hệ thống Server SmartHome để sử lý.\r\n\r\nThiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury hỗ trợ 4 kênh thu thập tín hiệu điểm NC/NO, còi báo động và cung cấp nguồn ra 12VDC-1A cho các cảm biến.", Price = 70000000, DeviceType = "Sensor", ManufacturerId = IdManu7 },
                new Device { Id = IdDevice10, DeviceName = "Công tắc 1 kênh SH-CT1Z-T2", Description = "Thiết bị SH-CT1Z-T2-PRO là công tắc cảm ứng 1 kênh được sử dụng trong hệ thống nhà thông minh SmartHome, hỗ trợ điều khiển 1 kênh để điều khiển các thiết bị điện.", Price = 4650000, DeviceType = "Switch", ManufacturerId = IdManu7 },
                  //Google 
                  new Device { Id = IdDevice11, DeviceName = "Khóa thông minh Google Nest x Yale Smart Lock", Description = "Google Nest Yale là sản phẩm khóa cửa thông minh của Google Nest và Yale. Sản phẩm thuộc công ty khóa hàng đầu thế giới – Yale. Là một trong những thương hiệu quốc tế lâu đời nhất. Yale là một trong những tên tuổi nổi tiếng và được kính trọng nhất trong ngành công nghiệp khóa. Công ty là một phần đáng tự hào của Habitat for Humanity. Đã cung cấp hơn 700.000 ổ khóa cho các ngôi nhà của Habitat for Humanity. Yale là một phần của Tập đoàn ASSA ABLOY, công ty hàng đầu thế giới về các giải pháp mở cửa.", Price = 6990000, DeviceType = "Sercurity", ManufacturerId = IdManu2 }
                );


/*
            var PackageDevice = new List<object>()
        {

            new { PackageId1, IdDevice1 },
            new { PackageId1, IdDevice2 },
            new { PackageId1, IdDevice3 },
            new { PackageId1, IdDevice4 },
            new { PackageId1, IdDevice5 },
            new { PackageId2, IdDevice6 },
            new { PackageId2, IdDevice7 },
            new { PackageId2, IdDevice8 },
            new { PackageId2, IdDevice9 }
        };

            builder.Entity<Device>().HasMany(d => d.Packages).WithMany(p => p.Devices).UsingEntity(j => j.ToTable("PackageDevice")).HasData(PackageDevice);
*/
        }
    }
}
