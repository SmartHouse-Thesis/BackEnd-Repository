using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Role_RoleId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("16ea920a-8627-437c-8350-19efd59a8482"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("23f8ef1a-7f69-4d8b-bd0f-ee5b2ee067a5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c319d383-06d7-4720-9b75-694c0e5c0dca"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("cb0e966a-118a-49fd-8a6c-1f2f4bf74956"));

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Contracts",
                newName: "Email");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "Name", "PackageId" },
                values: new object[,]
                {
                    { new Guid("35b04309-1769-4284-9505-05a4e86d4773"), null, null, null, null, null, null, "LG", null },
                    { new Guid("3ca3764b-5442-45e1-8b1f-7d5ad7cd5e3d"), null, null, null, null, null, null, "BKAV", null },
                    { new Guid("52c89c30-ece4-4922-a7cc-070c2d9272bc"), null, null, null, null, null, null, "Vsmart", null },
                    { new Guid("6e70c21f-9620-41c2-87ec-1ad50fbb1a3e"), null, null, null, null, null, null, "Javis", null },
                    { new Guid("81f53fc6-5418-4ec3-abbb-abf6f5a6f7ea"), null, null, null, null, null, null, "Google", null },
                    { new Guid("890c62e4-9de1-47bf-9d69-59f28992e6ae"), null, null, null, null, null, null, "Xiaomi", null },
                    { new Guid("89e51956-bfbe-4167-9539-c510c71b9c44"), null, null, null, null, null, null, "Philip", null },
                    { new Guid("9c4206ac-d3e9-4f50-bd7f-806567121a98"), null, null, null, null, null, null, "Nest ", null },
                    { new Guid("fa706086-2d25-4448-b79f-91b871f2d374"), null, null, null, null, null, null, "Philip", null }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "ContractId", "CreatedBy", "CreationDate", "DeletedBy", "Description", "FeedbackId", "ImageId", "IsDelete", "ManufacturerId", "ModificationBy", "ModificationDate", "OwnerId", "PackageName", "PolicyId", "Price", "PromotionId", "PromotionPrice" },
                values: new object[,]
                {
                    { new Guid("7793e328-7b7a-4f1f-9117-896dadcf6420"), null, null, null, null, "", null, null, null, null, null, null, null, "Gói Sản Phẩm Nhà thông Minh BKAV", null, 105000000m, null, null },
                    { new Guid("ba5c5a29-e48d-40dd-a289-c1fc7e3e6721"), null, null, null, null, "Mi Home hỗ trợ rất nhiều thiết bị nhà thông minh như: camera, máy lọc không khí, quạt điện, robot hút bụi … được kết nối và điều khiển qua ứng dụng.\r\n\r\nTùy vào từng hoàn cảnh mà người dùng có thể dễ dàng điều khiển tự động như: đèn sáng, quạt quay, robot hoạt động … Điều này giúp bạn không cần phải tự động phải ở gần thiết bị mới làm được.\r\n\r\nHiểu được điều này, Xiaomi đã cho ra mắt bộ thiết bị nhà thông mình Xiaomi Smart Home Security Kit 5 Trong 1. Sản phẩm bao gồm:\r\n\r\nBộ điều khiển trung tâm;\r\nCảm biến chuyển động;\r\nCảm biến đóng / mở cửa;\r\nChuông cửa;\r\nỔ cắm thông minh.", null, null, null, null, null, null, null, "Bộ Thiết Bị Nhà Thông Minh Xiaomi Smart Home Security Kit 5 Trong 1", null, 1490000m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("0eb86888-54f4-4ec1-8b7f-6e4efcf0f421"), null, null, null, null, null, null, "Staff" },
                    { new Guid("2fa5da1a-8f00-4c40-81de-c6dad46509a6"), null, null, null, null, null, null, "Teller" },
                    { new Guid("a1c91713-12bb-4cc6-bedd-32c35c0fd939"), null, null, null, null, null, null, "Customer" },
                    { new Guid("acdbcba2-c11e-474a-9084-74b264ed734f"), null, null, null, null, null, null, "Owner" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Address", "CreatedBy", "CreationDate", "DeletedBy", "Email", "FirstName", "IsDelete", "LastName", "ModificationBy", "ModificationDate", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { new Guid("05bc08ba-aa15-4593-a8c3-2b4f10bf208d"), "Customer Address", null, new DateTime(2024, 1, 28, 16, 28, 41, 576, DateTimeKind.Local).AddTicks(495), null, "Customer@gmail.com", "Customer", null, "Account", null, null, "customer", null, new Guid("a1c91713-12bb-4cc6-bedd-32c35c0fd939") },
                    { new Guid("1e84f2b9-88c6-4bde-9e8b-f1135be77ba0"), "Owner Address", null, new DateTime(2024, 1, 28, 16, 28, 41, 576, DateTimeKind.Local).AddTicks(439), null, "Owner@gmail.com", "Owner", null, "Account", null, null, "owner", null, new Guid("acdbcba2-c11e-474a-9084-74b264ed734f") },
                    { new Guid("6c798e61-414b-468e-b9fb-79b16dc6b643"), "Teller Address", null, new DateTime(2024, 1, 28, 16, 28, 41, 576, DateTimeKind.Local).AddTicks(452), null, "Teller@gmail.com", "Teller", null, "Account", null, null, "teller", null, new Guid("2fa5da1a-8f00-4c40-81de-c6dad46509a6") },
                    { new Guid("8856a279-7edb-4b31-bd1e-1828fcd39201"), "Staff 1 Address", null, new DateTime(2024, 1, 28, 16, 28, 41, 576, DateTimeKind.Local).AddTicks(499), null, "Staff1@gmail.com", "Staff 1", null, "Account", null, null, "staff1", null, new Guid("0eb86888-54f4-4ec1-8b7f-6e4efcf0f421") },
                    { new Guid("8e17c5e1-2cfa-4018-b840-8ec9753ac14a"), "Staff Lead Address", null, new DateTime(2024, 1, 28, 16, 28, 41, 576, DateTimeKind.Local).AddTicks(497), null, "StaffLead@gmail.com", "Staff Lead", null, "Account", null, null, "stafflead", null, new Guid("0eb86888-54f4-4ec1-8b7f-6e4efcf0f421") },
                    { new Guid("abac982f-2a54-4a79-8166-ec6ab33b7118"), "Staff 2 Address", null, new DateTime(2024, 1, 28, 16, 28, 41, 576, DateTimeKind.Local).AddTicks(500), null, "Staff2@gmail.com", "Staff 2", null, "Account", null, null, "staff2", null, new Guid("0eb86888-54f4-4ec1-8b7f-6e4efcf0f421") }
                });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "Description", "DeviceName", "DeviceType", "IsDelete", "ManufacturerId", "ModificationBy", "ModificationDate", "OrderId", "OwnerId", "Price" },
                values: new object[,]
                {
                    { new Guid("15927d8a-a545-4dd9-bf75-30aac9dd0f7b"), null, null, null, "Công tắc 4 kênh SH-CT4Z-LITE là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", "Công tắc 4 kênh SH-CT4Z-T2", "Switch", null, new Guid("3ca3764b-5442-45e1-8b1f-7d5ad7cd5e3d"), null, null, null, null, 4950000m },
                    { new Guid("23fe2562-c774-461b-83fb-5dfe84168ba4"), null, null, null, "Xiaomi gen 2 RTCGQ02LM phiên bản cảm biến chuyển động thế hệ mới mà người dùng nhà thông minh của Xiaomi không thể bỏ qua. Thiết bị giúp phát hiện chuyển động con người, vật nuôi, ánh sáng,...có độ chính xác cao đồng thời cũng được hỗ trợ liên kết với nhiều thiết bị nhà thông minh khác.", "Cảm biến người, chuyển động Xiaomi gen 2 RTCGQ02LM", "Sensor", null, new Guid("890c62e4-9de1-47bf-9d69-59f28992e6ae"), null, null, null, null, 290000m },
                    { new Guid("24241f54-4f90-4fe6-8525-099e8ae0c03e"), null, null, null, "Thiết bị được kết nối qua ứng dụng Mi Home, có thế sử dụng với các thiết bị khác. Một trong những tính năng tôi ưu nhất là điều khiển chức năng của phích cắm tắt/bật từ xa.\r\n\r\nBạn cũng có thể đặt hẹn giờ tắt/bật cho từng ổ cắm. Điều này giúp cho bạn thuận tiện hơn trong khi sử dụng các sản phẩm không phải đồ thông minh khác mà muốn điều khiển từ xa.", "Ổ cắm thông minh – Zigbee", "Electronic", null, new Guid("890c62e4-9de1-47bf-9d69-59f28992e6ae"), null, null, null, null, 255000m },
                    { new Guid("30be0bf3-561e-4031-a885-5399c00aa935"), null, null, null, "Thiết bị SH-CT1Z-T2-PRO là công tắc cảm ứng 1 kênh được sử dụng trong hệ thống nhà thông minh SmartHome, hỗ trợ điều khiển 1 kênh để điều khiển các thiết bị điện.", "Công tắc 1 kênh SH-CT1Z-T2", "Switch", null, new Guid("3ca3764b-5442-45e1-8b1f-7d5ad7cd5e3d"), null, null, null, null, 4650000m },
                    { new Guid("6575b505-8b16-46a1-a9cc-de1a9374a7ac"), null, null, null, "Nếu là tín đồ của các thiết bị ngôi nhà thông minh Xiaomi thì bộ điều khiển trung tâm Homekit Xiaomi Gateway V3 sẽ là lựa chọn mà bạn không thể bỏ qua. Thiết bị giúp bạn có thể điều khiển các thiết bị trong bộ Homekit với kết nối ổn định, nhanh chóng và đặc biệt là bảo mật quyền riêng tư tốt.", "Xiaomi Smart Home Gateway", "Gateway", null, new Guid("890c62e4-9de1-47bf-9d69-59f28992e6ae"), null, null, null, null, 800000m },
                    { new Guid("6a120e3b-10fd-44bc-bee9-6aaad937c895"), null, null, null, "Nếu gia đình bạn thường xuyên có khách đến thăm hoặc để tránh trường hợp những tên trộm có thủ thuật tinh vi để xâm nhập vào nhà bạn thì việc trang bị Chuông cửa thông minh Xiaomi Linptech G6L-Wifi-SW sẽ là sự bảo vệ hợp lý và hiệu quả nhất.", "Chuông cửa thông minh Xiaomi Linptech G6L-Wifi-SW", "Sensor", null, new Guid("890c62e4-9de1-47bf-9d69-59f28992e6ae"), null, null, null, null, 399000m },
                    { new Guid("7a68ff8b-45c7-496b-bc2a-d74a7809a470"), null, null, null, "Công tắc Công tắc cảm ứng 6 kênh SH-CC6-Lite là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", "Công tắc cảm ứng 6 kênh SH-CC6", "Switch", null, new Guid("3ca3764b-5442-45e1-8b1f-7d5ad7cd5e3d"), null, null, null, null, 12500000m },
                    { new Guid("b0b59a38-2c5d-4bef-a596-62ade860f0a5"), null, null, null, "Google Nest Yale là sản phẩm khóa cửa thông minh của Google Nest và Yale. Sản phẩm thuộc công ty khóa hàng đầu thế giới – Yale. Là một trong những thương hiệu quốc tế lâu đời nhất. Yale là một trong những tên tuổi nổi tiếng và được kính trọng nhất trong ngành công nghiệp khóa. Công ty là một phần đáng tự hào của Habitat for Humanity. Đã cung cấp hơn 700.000 ổ khóa cho các ngôi nhà của Habitat for Humanity. Yale là một phần của Tập đoàn ASSA ABLOY, công ty hàng đầu thế giới về các giải pháp mở cửa.", "Khóa thông minh Google Nest x Yale Smart Lock", "Sercurity", null, new Guid("81f53fc6-5418-4ec3-abbb-abf6f5a6f7ea"), null, null, null, null, 6990000m },
                    { new Guid("b8a5a1f5-a10f-4aea-98b9-35e7320bcf13"), null, null, null, "Thiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury là thiết bị an ninh được sử dụng trong hệ thống nhà thông minh SmartHome, có chức năng thu thập tín hiệu từ các cảm biến an ninh như: hàng rào điện tử, cảm biến vị trí, cảm biến kính vỡ, cảm biến báo khói...\r\n\r\nThiết bị được kết nối với hệ thống thông qua mạng truyền thông không dây ZigBee. Tín hiệu an ninh sau khi thu thập, sẽ được thiết bị chuyển đến hệ thống Server SmartHome để sử lý.\r\n\r\nThiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury hỗ trợ 4 kênh thu thập tín hiệu điểm NC/NO, còi báo động và cung cấp nguồn ra 12VDC-1A cho các cảm biến.", "Thiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury", "Sensor", null, new Guid("3ca3764b-5442-45e1-8b1f-7d5ad7cd5e3d"), null, null, null, null, 70000000m },
                    { new Guid("cf15ffd2-b0c0-4c48-810e-fd8f2186dcc5"), null, null, null, "thiết bị giúp theo dõi và thông báo trạng thái đóng, mở cửa cho ngôi nhà của bạn một cách nhanh chóng và chính xác theo thời gian thực. Sản phẩm là một thiết bị không thể bỏ qua nếu người dùng mong muốn xây dựng nhà thông minh.", "Cảm biến gắn cửa Xiaomi 2 MCCGQ02HL", "Sensor", null, new Guid("890c62e4-9de1-47bf-9d69-59f28992e6ae"), null, null, null, null, 180000m },
                    { new Guid("fcca07db-9a24-4393-bcf9-9fc046efe459"), null, null, null, "Thiết bị điều khiển trung tâm SH-HC là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", "THIẾT BỊ ĐIỀU KHIỂN TRUNG TÂM SH-HC", "Gateway", null, new Guid("3ca3764b-5442-45e1-8b1f-7d5ad7cd5e3d"), null, null, null, null, 18000000m }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[] { new Guid("05bc08ba-aa15-4593-a8c3-2b4f10bf208d"), null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[] { new Guid("1e84f2b9-88c6-4bde-9e8b-f1135be77ba0"), null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ManageId", "ModificationBy", "ModificationDate", "RoleName", "isLeader" },
                values: new object[,]
                {
                    { new Guid("8856a279-7edb-4b31-bd1e-1828fcd39201"), null, null, null, null, null, null, null, null, null },
                    { new Guid("8e17c5e1-2cfa-4018-b840-8ec9753ac14a"), null, null, null, null, null, null, null, null, null },
                    { new Guid("abac982f-2a54-4a79-8166-ec6ab33b7118"), null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Tellers",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ManufacturerId", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[] { new Guid("6c798e61-414b-468e-b9fb-79b16dc6b643"), null, null, null, null, null, null, null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Role_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Role_RoleId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("05bc08ba-aa15-4593-a8c3-2b4f10bf208d"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("15927d8a-a545-4dd9-bf75-30aac9dd0f7b"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("23fe2562-c774-461b-83fb-5dfe84168ba4"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("24241f54-4f90-4fe6-8525-099e8ae0c03e"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("30be0bf3-561e-4031-a885-5399c00aa935"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("6575b505-8b16-46a1-a9cc-de1a9374a7ac"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("6a120e3b-10fd-44bc-bee9-6aaad937c895"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("7a68ff8b-45c7-496b-bc2a-d74a7809a470"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("b0b59a38-2c5d-4bef-a596-62ade860f0a5"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("b8a5a1f5-a10f-4aea-98b9-35e7320bcf13"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("cf15ffd2-b0c0-4c48-810e-fd8f2186dcc5"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("fcca07db-9a24-4393-bcf9-9fc046efe459"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("35b04309-1769-4284-9505-05a4e86d4773"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("52c89c30-ece4-4922-a7cc-070c2d9272bc"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("6e70c21f-9620-41c2-87ec-1ad50fbb1a3e"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("89e51956-bfbe-4167-9539-c510c71b9c44"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("9c4206ac-d3e9-4f50-bd7f-806567121a98"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("fa706086-2d25-4448-b79f-91b871f2d374"));

            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "Id",
                keyValue: new Guid("1e84f2b9-88c6-4bde-9e8b-f1135be77ba0"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("7793e328-7b7a-4f1f-9117-896dadcf6420"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("ba5c5a29-e48d-40dd-a289-c1fc7e3e6721"));

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: new Guid("8856a279-7edb-4b31-bd1e-1828fcd39201"));

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: new Guid("8e17c5e1-2cfa-4018-b840-8ec9753ac14a"));

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: new Guid("abac982f-2a54-4a79-8166-ec6ab33b7118"));

            migrationBuilder.DeleteData(
                table: "Tellers",
                keyColumn: "Id",
                keyValue: new Guid("6c798e61-414b-468e-b9fb-79b16dc6b643"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("05bc08ba-aa15-4593-a8c3-2b4f10bf208d"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1e84f2b9-88c6-4bde-9e8b-f1135be77ba0"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("6c798e61-414b-468e-b9fb-79b16dc6b643"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("8856a279-7edb-4b31-bd1e-1828fcd39201"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("8e17c5e1-2cfa-4018-b840-8ec9753ac14a"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("abac982f-2a54-4a79-8166-ec6ab33b7118"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("3ca3764b-5442-45e1-8b1f-7d5ad7cd5e3d"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("81f53fc6-5418-4ec3-abbb-abf6f5a6f7ea"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("890c62e4-9de1-47bf-9d69-59f28992e6ae"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0eb86888-54f4-4ec1-8b7f-6e4efcf0f421"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2fa5da1a-8f00-4c40-81de-c6dad46509a6"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1c91713-12bb-4cc6-bedd-32c35c0fd939"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("acdbcba2-c11e-474a-9084-74b264ed734f"));

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contracts",
                newName: "Title");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("16ea920a-8627-437c-8350-19efd59a8482"), null, null, null, null, null, null, "Owner" },
                    { new Guid("23f8ef1a-7f69-4d8b-bd0f-ee5b2ee067a5"), null, null, null, null, null, null, "Teller" },
                    { new Guid("c319d383-06d7-4720-9b75-694c0e5c0dca"), null, null, null, null, null, null, "Staff" },
                    { new Guid("cb0e966a-118a-49fd-8a6c-1f2f4bf74956"), null, null, null, null, null, null, "Customer" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Role_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}
