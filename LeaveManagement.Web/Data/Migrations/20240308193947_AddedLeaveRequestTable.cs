using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Canceled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
