using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRequstComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55710026-F12D-4053-AC4F-693C52A9E53A",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5266129-a4be-4d46-a148-e68ef624fe81", new DateTime(2024, 3, 9, 0, 34, 38, 567, DateTimeKind.Utc).AddTicks(591), "AQAAAAIAAYagAAAAELVkmYqKfvsrmaltJq5us0HMRRcgodn2XV7KLmBpdvVhLq8eiQivXh/MlJ7NPtdOGg==", "2a3d36b4-1ea6-4dce-8fc5-60a04cfc9bbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0d243f3-f4c7-4a89-8e40-c67ca826ab60",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de20b8f1-6c1a-4511-986b-8cab5e29452a", new DateTime(2024, 3, 9, 0, 34, 38, 484, DateTimeKind.Utc).AddTicks(2262), "AQAAAAIAAYagAAAAECe0+yVRYjEarOvprfLmOnlFsFcu8wWsHY+DE7CdrmqDLXW6z7/USuNB1FDbkMdfIg==", "b7efeba2-1ecd-44c0-9c82-5bebab1b93b5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55710026-F12D-4053-AC4F-693C52A9E53A",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b498596e-f2e0-49cc-99e2-c898fac7e14a", new DateTime(2024, 3, 8, 19, 39, 44, 635, DateTimeKind.Utc).AddTicks(1004), "AQAAAAIAAYagAAAAECMbLJMGuS49/5VVsLcJA0Ce2bkARDx7E1MjUnYRBEN5dr7jQxkwnjn1rjq3IwBXuQ==", "a8e037be-bedf-41b6-ae78-53fbff267c1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0d243f3-f4c7-4a89-8e40-c67ca826ab60",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05a59a50-6e13-4e5f-a21a-b67033ea9ccf", new DateTime(2024, 3, 8, 19, 39, 44, 557, DateTimeKind.Utc).AddTicks(9485), "AQAAAAIAAYagAAAAEAtCspZ0SK2qmUTsar2gb1PNlrRSCxnsOxCpkI1dbtJEq/QEezqJvH1QP0cVreH1Ag==", "5866e353-80fb-4262-b80e-bf05febd2db5" });
        }
    }
}
