using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7CD3EE61-EBCF-4FC5-9183-27391791C73B", null, "User", "USER" },
                    { "816845F3-2DB1-4711-89A3-73F9367AD1D1", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "55710026-F12D-4053-AC4F-693C52A9E53A", 0, "d67ec41a-676e-4ada-a14d-4cfabc89c72f", new DateTime(2024, 3, 6, 21, 29, 10, 688, DateTimeKind.Utc).AddTicks(1744), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mark_devol@cox.net", true, "Mark", "DeVol", false, null, "MARK_DEVOL@COX.NET", "MARK_DEVOL@COX.NET", "AQAAAAIAAYagAAAAEGfakKLqAWoFcY0ebsaAtWjccvguMJwEqvUP1DvT6lPc2JG79N1DO6IV7vabTneaSQ==", null, false, "ae94f181-ae3b-45dc-aa98-4ed441d09bc6", null, false, "mark_devol@cox.net" },
                    { "b0d243f3-f4c7-4a89-8e40-c67ca826ab60", 0, "ff95ecf1-cfed-4cf3-bd71-151301967856", new DateTime(2024, 3, 6, 21, 29, 10, 583, DateTimeKind.Utc).AddTicks(3161), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mark@devols.net", true, "Mark", "DeVol", false, null, "MARK@DEVOLS.NET", "MARK@DEVOLS.NET", "AQAAAAIAAYagAAAAEAMb8sWclZleymoOJBBmxCfeahircHFlTMLZ+OtjslD9fg9s0nthFnXEHCFqYxw2GQ==", null, false, "7871ad42-69d9-4970-8d32-0acc57575c69", null, false, "mark@devols.net" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7CD3EE61-EBCF-4FC5-9183-27391791C73B", "55710026-F12D-4053-AC4F-693C52A9E53A" },
                    { "816845F3-2DB1-4711-89A3-73F9367AD1D1", "b0d243f3-f4c7-4a89-8e40-c67ca826ab60" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7CD3EE61-EBCF-4FC5-9183-27391791C73B", "55710026-F12D-4053-AC4F-693C52A9E53A" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "816845F3-2DB1-4711-89A3-73F9367AD1D1", "b0d243f3-f4c7-4a89-8e40-c67ca826ab60" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7CD3EE61-EBCF-4FC5-9183-27391791C73B");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "816845F3-2DB1-4711-89A3-73F9367AD1D1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55710026-F12D-4053-AC4F-693C52A9E53A");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0d243f3-f4c7-4a89-8e40-c67ca826ab60");
        }
    }
}
