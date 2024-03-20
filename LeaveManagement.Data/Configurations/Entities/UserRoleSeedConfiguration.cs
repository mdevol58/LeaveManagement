using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "816845F3-2DB1-4711-89A3-73F9367AD1D1",
                    UserId = "b0d243f3-f4c7-4a89-8e40-c67ca826ab60"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "7CD3EE61-EBCF-4FC5-9183-27391791C73B",
                    UserId = "55710026-F12D-4053-AC4F-693C52A9E53A"
                }
            );
        }
    }
}