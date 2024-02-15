using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Feedbacks_FeedbackId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_FeedbackId",
                table: "Packages");

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

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Packages");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptanceDate",
                table: "Acceptances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "Name", "PackageId" },
                values: new object[,]
                {
                    { new Guid("07a9ae29-3f85-45f5-a3f4-554786edeadb"), null, null, null, null, null, null, "Javis", null },
                    { new Guid("304ee430-abf3-481a-b5f8-a7c8f2b207fe"), null, null, null, null, null, null, "Philip", null },
                    { new Guid("327ae126-2a8a-43a4-9f08-27c174097294"), null, null, null, null, null, null, "Xiaomi", null },
                    { new Guid("37ddf51c-c7ce-4226-bd08-798399edbd1f"), null, null, null, null, null, null, "LG", null },
                    { new Guid("3c3a0560-aae1-40c0-8167-71071beb7bf3"), null, null, null, null, null, null, "Vsmart", null },
                    { new Guid("537c5b9f-60bb-43fd-afce-5e76e47e49d9"), null, null, null, null, null, null, "BKAV", null },
                    { new Guid("5986ec27-d9df-4923-80e7-15a6e3a69b9d"), null, null, null, null, null, null, "Google", null },
                    { new Guid("8f8d8964-fc29-4abd-ba6e-fcea10a05412"), null, null, null, null, null, null, "Nest ", null },
                    { new Guid("bddf66ef-bd82-4783-82c0-82a59f2e9fcc"), null, null, null, null, null, null, "Philip", null }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "ContractId", "CreatedBy", "CreationDate", "DeletedBy", "Description", "ImageId", "IsDelete", "ManufacturerId", "ModificationBy", "ModificationDate", "OwnerId", "PackageName", "PolicyId", "Price", "PromotionId", "PromotionPrice" },
                values: new object[,]
                {
                    { new Guid("927c54bd-9b22-4fb7-8b5d-c4c94edd4ec6"), null, null, null, null, "Mi Home hỗ trợ rất nhiều thiết bị nhà thông minh như: camera, máy lọc không khí, quạt điện, robot hút bụi … được kết nối và điều khiển qua ứng dụng.\r\n\r\nTùy vào từng hoàn cảnh mà người dùng có thể dễ dàng điều khiển tự động như: đèn sáng, quạt quay, robot hoạt động … Điều này giúp bạn không cần phải tự động phải ở gần thiết bị mới làm được.\r\n\r\nHiểu được điều này, Xiaomi đã cho ra mắt bộ thiết bị nhà thông mình Xiaomi Smart Home Security Kit 5 Trong 1. Sản phẩm bao gồm:\r\n\r\nBộ điều khiển trung tâm;\r\nCảm biến chuyển động;\r\nCảm biến đóng / mở cửa;\r\nChuông cửa;\r\nỔ cắm thông minh.", null, null, null, null, null, null, "Bộ Thiết Bị Nhà Thông Minh Xiaomi Smart Home Security Kit 5 Trong 1", null, 1490000m, null, null },
                    { new Guid("a59f4d3c-0a89-47a4-9873-602c2f8af06e"), null, null, null, null, "", null, null, null, null, null, null, "Gói Sản Phẩm Nhà thông Minh BKAV", null, 105000000m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("26c6632a-19cb-4805-82a8-a4a31eef93ed"), null, null, null, null, null, null, "Customer" },
                    { new Guid("62fe4e6c-de9c-4877-97af-8ddce2248534"), null, null, null, null, null, null, "Teller" },
                    { new Guid("7e368f4f-efc9-4573-8306-a3f5f794014e"), null, null, null, null, null, null, "Owner" },
                    { new Guid("ab8b0c69-016b-48f0-9e0b-ed9b0e1191b3"), null, null, null, null, null, null, "Staff" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Address", "CreatedBy", "CreationDate", "DeletedBy", "Email", "FirstName", "IsDelete", "LastName", "ModificationBy", "ModificationDate", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { new Guid("10db3db8-194f-4433-8c52-9c4500ea4617"), "Teller Address", null, new DateTime(2024, 2, 16, 2, 10, 5, 388, DateTimeKind.Local).AddTicks(4839), null, "Teller@gmail.com", "Teller", null, "Account", null, null, "teller", null, new Guid("62fe4e6c-de9c-4877-97af-8ddce2248534") },
                    { new Guid("2f4da093-b0bd-45fe-ab10-2b79d79264c2"), "Staff Lead Address", null, new DateTime(2024, 2, 16, 2, 10, 5, 388, DateTimeKind.Local).AddTicks(4843), null, "StaffLead@gmail.com", "Staff Lead", null, "Account", null, null, "stafflead", null, new Guid("ab8b0c69-016b-48f0-9e0b-ed9b0e1191b3") },
                    { new Guid("74fb9e53-e64c-44b7-84ee-91bdc8420e3f"), "Staff 2 Address", null, new DateTime(2024, 2, 16, 2, 10, 5, 388, DateTimeKind.Local).AddTicks(4890), null, "Staff2@gmail.com", "Staff 2", null, "Account", null, null, "staff2", null, new Guid("ab8b0c69-016b-48f0-9e0b-ed9b0e1191b3") },
                    { new Guid("8970c626-87fa-411e-85e3-2cec17626700"), "Staff 1 Address", null, new DateTime(2024, 2, 16, 2, 10, 5, 388, DateTimeKind.Local).AddTicks(4888), null, "Staff1@gmail.com", "Staff 1", null, "Account", null, null, "staff1", null, new Guid("ab8b0c69-016b-48f0-9e0b-ed9b0e1191b3") },
                    { new Guid("a6bea73d-e8c1-48f5-b5ea-121483fe9dd9"), "Owner Address", null, new DateTime(2024, 2, 16, 2, 10, 5, 388, DateTimeKind.Local).AddTicks(4825), null, "Owner@gmail.com", "Owner", null, "Account", null, null, "owner", null, new Guid("7e368f4f-efc9-4573-8306-a3f5f794014e") },
                    { new Guid("e34f837c-832e-4974-97ae-32a4a5518922"), "Customer Address", null, new DateTime(2024, 2, 16, 2, 10, 5, 388, DateTimeKind.Local).AddTicks(4841), null, "Customer@gmail.com", "Customer", null, "Account", null, null, "customer", null, new Guid("26c6632a-19cb-4805-82a8-a4a31eef93ed") }
                });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "Description", "DeviceName", "DeviceType", "IsDelete", "ManufacturerId", "ModificationBy", "ModificationDate", "OrderId", "OwnerId", "Price" },
                values: new object[,]
                {
                    { new Guid("040f7b39-7ae4-44a7-8e5a-9c806f937eca"), null, null, null, "Thiết bị điều khiển trung tâm SH-HC là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", "THIẾT BỊ ĐIỀU KHIỂN TRUNG TÂM SH-HC", "Gateway", null, new Guid("537c5b9f-60bb-43fd-afce-5e76e47e49d9"), null, null, null, null, 18000000m },
                    { new Guid("09a09922-024e-486b-bb1c-de9ca7af7a8e"), null, null, null, "Nếu là tín đồ của các thiết bị ngôi nhà thông minh Xiaomi thì bộ điều khiển trung tâm Homekit Xiaomi Gateway V3 sẽ là lựa chọn mà bạn không thể bỏ qua. Thiết bị giúp bạn có thể điều khiển các thiết bị trong bộ Homekit với kết nối ổn định, nhanh chóng và đặc biệt là bảo mật quyền riêng tư tốt.", "Xiaomi Smart Home Gateway", "Gateway", null, new Guid("327ae126-2a8a-43a4-9f08-27c174097294"), null, null, null, null, 800000m },
                    { new Guid("5972e2cb-40f6-4d33-8b39-40d5ec836f53"), null, null, null, "Thiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury là thiết bị an ninh được sử dụng trong hệ thống nhà thông minh SmartHome, có chức năng thu thập tín hiệu từ các cảm biến an ninh như: hàng rào điện tử, cảm biến vị trí, cảm biến kính vỡ, cảm biến báo khói...\r\n\r\nThiết bị được kết nối với hệ thống thông qua mạng truyền thông không dây ZigBee. Tín hiệu an ninh sau khi thu thập, sẽ được thiết bị chuyển đến hệ thống Server SmartHome để sử lý.\r\n\r\nThiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury hỗ trợ 4 kênh thu thập tín hiệu điểm NC/NO, còi báo động và cung cấp nguồn ra 12VDC-1A cho các cảm biến.", "Thiết bị kiểm soát an ninh SH-SCZ-Pro bản Luxury", "Sensor", null, new Guid("537c5b9f-60bb-43fd-afce-5e76e47e49d9"), null, null, null, null, 70000000m },
                    { new Guid("917df600-c9a0-49d9-b176-6553e7b491f0"), null, null, null, "Nếu gia đình bạn thường xuyên có khách đến thăm hoặc để tránh trường hợp những tên trộm có thủ thuật tinh vi để xâm nhập vào nhà bạn thì việc trang bị Chuông cửa thông minh Xiaomi Linptech G6L-Wifi-SW sẽ là sự bảo vệ hợp lý và hiệu quả nhất.", "Chuông cửa thông minh Xiaomi Linptech G6L-Wifi-SW", "Sensor", null, new Guid("327ae126-2a8a-43a4-9f08-27c174097294"), null, null, null, null, 399000m },
                    { new Guid("91cc3ef2-f4e2-4262-ab22-0261fce93640"), null, null, null, "Công tắc 4 kênh SH-CT4Z-LITE là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", "Công tắc 4 kênh SH-CT4Z-T2", "Switch", null, new Guid("537c5b9f-60bb-43fd-afce-5e76e47e49d9"), null, null, null, null, 4950000m },
                    { new Guid("91f3c1b6-c4b4-4061-81b5-ff4fd8089c8c"), null, null, null, "thiết bị giúp theo dõi và thông báo trạng thái đóng, mở cửa cho ngôi nhà của bạn một cách nhanh chóng và chính xác theo thời gian thực. Sản phẩm là một thiết bị không thể bỏ qua nếu người dùng mong muốn xây dựng nhà thông minh.", "Cảm biến gắn cửa Xiaomi 2 MCCGQ02HL", "Sensor", null, new Guid("327ae126-2a8a-43a4-9f08-27c174097294"), null, null, null, null, 180000m },
                    { new Guid("bd8e9511-cb36-4bd1-b8d9-637612c67500"), null, null, null, "Thiết bị SH-CT1Z-T2-PRO là công tắc cảm ứng 1 kênh được sử dụng trong hệ thống nhà thông minh SmartHome, hỗ trợ điều khiển 1 kênh để điều khiển các thiết bị điện.", "Công tắc 1 kênh SH-CT1Z-T2", "Switch", null, new Guid("537c5b9f-60bb-43fd-afce-5e76e47e49d9"), null, null, null, null, 4650000m },
                    { new Guid("e3fddf74-41de-47ac-a63c-f761f8941e32"), null, null, null, "Google Nest Yale là sản phẩm khóa cửa thông minh của Google Nest và Yale. Sản phẩm thuộc công ty khóa hàng đầu thế giới – Yale. Là một trong những thương hiệu quốc tế lâu đời nhất. Yale là một trong những tên tuổi nổi tiếng và được kính trọng nhất trong ngành công nghiệp khóa. Công ty là một phần đáng tự hào của Habitat for Humanity. Đã cung cấp hơn 700.000 ổ khóa cho các ngôi nhà của Habitat for Humanity. Yale là một phần của Tập đoàn ASSA ABLOY, công ty hàng đầu thế giới về các giải pháp mở cửa.", "Khóa thông minh Google Nest x Yale Smart Lock", "Sercurity", null, new Guid("5986ec27-d9df-4923-80e7-15a6e3a69b9d"), null, null, null, null, 6990000m },
                    { new Guid("ed1f20c6-289b-4e58-bef8-ab65e7338b31"), null, null, null, "Xiaomi gen 2 RTCGQ02LM phiên bản cảm biến chuyển động thế hệ mới mà người dùng nhà thông minh của Xiaomi không thể bỏ qua. Thiết bị giúp phát hiện chuyển động con người, vật nuôi, ánh sáng,...có độ chính xác cao đồng thời cũng được hỗ trợ liên kết với nhiều thiết bị nhà thông minh khác.", "Cảm biến người, chuyển động Xiaomi gen 2 RTCGQ02LM", "Sensor", null, new Guid("327ae126-2a8a-43a4-9f08-27c174097294"), null, null, null, null, 290000m },
                    { new Guid("fd94fac6-d57c-4bda-926d-bb4ce2e7b290"), null, null, null, "Công tắc Công tắc cảm ứng 6 kênh SH-CC6-Lite là sản phẩm của nhà thông minh Bkav SmartHome, sản xuất tại Việt Nam với linh kiện cốt lõi nhập khẩu từ Châu Âu như: Qualcomm, Microchip, Osram...và kính cường lực chống xước Gorilla Glass - Nhật Bản (loại kính dùng cho điện thoại thông minh cao cấp). Giao diện điều khiển 3D trạng thái.", "Công tắc cảm ứng 6 kênh SH-CC6", "Switch", null, new Guid("537c5b9f-60bb-43fd-afce-5e76e47e49d9"), null, null, null, null, 12500000m },
                    { new Guid("fdda5c07-adad-4b17-8312-339c436d7936"), null, null, null, "Thiết bị được kết nối qua ứng dụng Mi Home, có thế sử dụng với các thiết bị khác. Một trong những tính năng tôi ưu nhất là điều khiển chức năng của phích cắm tắt/bật từ xa.\r\n\r\nBạn cũng có thể đặt hẹn giờ tắt/bật cho từng ổ cắm. Điều này giúp cho bạn thuận tiện hơn trong khi sử dụng các sản phẩm không phải đồ thông minh khác mà muốn điều khiển từ xa.", "Ổ cắm thông minh – Zigbee", "Electronic", null, new Guid("327ae126-2a8a-43a4-9f08-27c174097294"), null, null, null, null, 255000m }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[] { new Guid("e34f837c-832e-4974-97ae-32a4a5518922"), null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[] { new Guid("a6bea73d-e8c1-48f5-b5ea-121483fe9dd9"), null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ManageId", "ModificationBy", "ModificationDate", "RoleName", "isLeader" },
                values: new object[,]
                {
                    { new Guid("2f4da093-b0bd-45fe-ab10-2b79d79264c2"), null, null, null, null, null, null, null, null, null },
                    { new Guid("74fb9e53-e64c-44b7-84ee-91bdc8420e3f"), null, null, null, null, null, null, null, null, null },
                    { new Guid("8970c626-87fa-411e-85e3-2cec17626700"), null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Tellers",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ManufacturerId", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[] { new Guid("10db3db8-194f-4433-8c52-9c4500ea4617"), null, null, null, null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PackageId",
                table: "Feedbacks",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Packages_PackageId",
                table: "Feedbacks",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Packages_PackageId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_PackageId",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e34f837c-832e-4974-97ae-32a4a5518922"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("040f7b39-7ae4-44a7-8e5a-9c806f937eca"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("09a09922-024e-486b-bb1c-de9ca7af7a8e"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("5972e2cb-40f6-4d33-8b39-40d5ec836f53"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("917df600-c9a0-49d9-b176-6553e7b491f0"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("91cc3ef2-f4e2-4262-ab22-0261fce93640"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("91f3c1b6-c4b4-4061-81b5-ff4fd8089c8c"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("bd8e9511-cb36-4bd1-b8d9-637612c67500"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("e3fddf74-41de-47ac-a63c-f761f8941e32"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("ed1f20c6-289b-4e58-bef8-ab65e7338b31"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("fd94fac6-d57c-4bda-926d-bb4ce2e7b290"));

            migrationBuilder.DeleteData(
                table: "Device",
                keyColumn: "Id",
                keyValue: new Guid("fdda5c07-adad-4b17-8312-339c436d7936"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("07a9ae29-3f85-45f5-a3f4-554786edeadb"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("304ee430-abf3-481a-b5f8-a7c8f2b207fe"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("37ddf51c-c7ce-4226-bd08-798399edbd1f"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("3c3a0560-aae1-40c0-8167-71071beb7bf3"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("8f8d8964-fc29-4abd-ba6e-fcea10a05412"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("bddf66ef-bd82-4783-82c0-82a59f2e9fcc"));

            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "Id",
                keyValue: new Guid("a6bea73d-e8c1-48f5-b5ea-121483fe9dd9"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("927c54bd-9b22-4fb7-8b5d-c4c94edd4ec6"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("a59f4d3c-0a89-47a4-9873-602c2f8af06e"));

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: new Guid("2f4da093-b0bd-45fe-ab10-2b79d79264c2"));

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: new Guid("74fb9e53-e64c-44b7-84ee-91bdc8420e3f"));

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: new Guid("8970c626-87fa-411e-85e3-2cec17626700"));

            migrationBuilder.DeleteData(
                table: "Tellers",
                keyColumn: "Id",
                keyValue: new Guid("10db3db8-194f-4433-8c52-9c4500ea4617"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("10db3db8-194f-4433-8c52-9c4500ea4617"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("2f4da093-b0bd-45fe-ab10-2b79d79264c2"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("74fb9e53-e64c-44b7-84ee-91bdc8420e3f"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("8970c626-87fa-411e-85e3-2cec17626700"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("a6bea73d-e8c1-48f5-b5ea-121483fe9dd9"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("e34f837c-832e-4974-97ae-32a4a5518922"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("327ae126-2a8a-43a4-9f08-27c174097294"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("537c5b9f-60bb-43fd-afce-5e76e47e49d9"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("5986ec27-d9df-4923-80e7-15a6e3a69b9d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("26c6632a-19cb-4805-82a8-a4a31eef93ed"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("62fe4e6c-de9c-4877-97af-8ddce2248534"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7e368f4f-efc9-4573-8306-a3f5f794014e"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ab8b0c69-016b-48f0-9e0b-ed9b0e1191b3"));

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "AcceptanceDate",
                table: "Acceptances");

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "Packages",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Packages_FeedbackId",
                table: "Packages",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Feedbacks_FeedbackId",
                table: "Packages",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }
    }
}
