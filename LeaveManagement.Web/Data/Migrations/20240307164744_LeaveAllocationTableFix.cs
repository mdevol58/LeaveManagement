using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class LeaveAllocationTableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55710026-F12D-4053-AC4F-693C52A9E53A",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da53468e-c3ae-42c0-b4e6-75a61979a2ee", new DateTime(2024, 3, 7, 16, 47, 40, 850, DateTimeKind.Utc).AddTicks(2074), "AQAAAAIAAYagAAAAEJFR6x9XO0/RKws1kLpo/ZDsj25MYdtnEyEhlSBWaTUYsuNLhvxciIynPop/dT3cMQ==", "57a93b59-557c-4d28-b50a-f4989dcc511e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0d243f3-f4c7-4a89-8e40-c67ca826ab60",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e16968da-a1f2-48dd-83eb-4f7b70adac4d", new DateTime(2024, 3, 7, 16, 47, 40, 742, DateTimeKind.Utc).AddTicks(9916), "AQAAAAIAAYagAAAAEByS63kt5ubuqhXA4zg+BfmY4pznmx7/Aq1ZxvZjlrYuBV3pDpKGbYSx/5fI15lQWw==", "89e54c52-ecb7-4941-8b06-c6a0c29da9e5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55710026-F12D-4053-AC4F-693C52A9E53A",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54fc995d-8302-4cda-b0ec-d56a4374b68f", new DateTime(2024, 3, 7, 1, 5, 39, 716, DateTimeKind.Utc).AddTicks(3581), "AQAAAAIAAYagAAAAEGrTOr81MEYLMZ3OkBXIzFAFVnGPzHdxplrFM1Y2ONfzCkM+FZe6+DcSHkruKCZscw==", "051bd25e-41a9-4e3e-a89d-c6efb6230b0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0d243f3-f4c7-4a89-8e40-c67ca826ab60",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "476d16de-785c-413a-b30f-f3517b5580c6", new DateTime(2024, 3, 7, 1, 5, 39, 549, DateTimeKind.Utc).AddTicks(7311), "AQAAAAIAAYagAAAAEPiFKP9E0wym1c3izrqLuOoSROAyfRD/poB8ahJGdUk5TE6g9r9tWaQ8wYtqYBPRlQ==", "8e1baf4c-86ca-4fd5-a16c-78c95048c079" });
        }
    }
}
