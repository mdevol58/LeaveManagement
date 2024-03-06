using LeaveManagement.Web.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();

            builder.HasData(
                new Employee
                {
                    Id = "b0d243f3-f4c7-4a89-8e40-c67ca826ab60",
                    Email = "mark@devols.net",
                    NormalizedEmail = "MARK@DEVOLS.NET",
                    UserName = "mark@devols.net",
                    NormalizedUserName = "MARK@DEVOLS.NET",
                    Firstname = "Mark",
                    Lastname = "DeVol",
                    DateJoined = DateTime.UtcNow,
                    PasswordHash = hasher.HashPassword(null, "Debugger58!"),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "55710026-F12D-4053-AC4F-693C52A9E53A",
                    Email = "mark_devol@cox.net",
                    NormalizedEmail = "MARK_DEVOL@COX.NET",
                    UserName = "mark_devol@cox.net",
                    NormalizedUserName = "MARK_DEVOL@COX.NET",
                    Firstname = "Mark",
                    Lastname = "DeVol",
                    DateJoined = DateTime.UtcNow,
                    PasswordHash = hasher.HashPassword(null, "Debugger58!"),
                    EmailConfirmed = true
                }
                );
        }
    }
}