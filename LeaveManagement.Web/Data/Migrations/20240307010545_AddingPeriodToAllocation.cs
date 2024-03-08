using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingPeriodToAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55710026-F12D-4053-AC4F-693C52A9E53A",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d67ec41a-676e-4ada-a14d-4cfabc89c72f", new DateTime(2024, 3, 6, 21, 29, 10, 688, DateTimeKind.Utc).AddTicks(1744), "AQAAAAIAAYagAAAAEGfakKLqAWoFcY0ebsaAtWjccvguMJwEqvUP1DvT6lPc2JG79N1DO6IV7vabTneaSQ==", "ae94f181-ae3b-45dc-aa98-4ed441d09bc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0d243f3-f4c7-4a89-8e40-c67ca826ab60",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff95ecf1-cfed-4cf3-bd71-151301967856", new DateTime(2024, 3, 6, 21, 29, 10, 583, DateTimeKind.Utc).AddTicks(3161), "AQAAAAIAAYagAAAAEAMb8sWclZleymoOJBBmxCfeahircHFlTMLZ+OtjslD9fg9s0nthFnXEHCFqYxw2GQ==", "7871ad42-69d9-4970-8d32-0acc57575c69" });
        }
    }
}
