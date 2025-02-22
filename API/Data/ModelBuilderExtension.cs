using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class ModelBuilderExtension
{
    public static void SeedIdentityData(this ModelBuilder builder)
    {
        var readerRoleId = "9e716b87-fa6b-4d0c-b2e7-9f73d28da9eb";
        var writerRoleId = "dedf408e-49da-4cc4-b3dc-b01eda58845b";
        var adminUserId = "18871800-3831-45c7-9856-d5a88e20951d";

        var roles = new List<IdentityRole>
        {
            new IdentityRole { Id = readerRoleId, Name = "Reader", NormalizedName = "READER", ConcurrencyStamp = readerRoleId },
            new IdentityRole { Id = writerRoleId, Name = "Writer", NormalizedName = "WRITER", ConcurrencyStamp = writerRoleId }
        };

        var admin = new IdentityUser
        {
            Id = adminUserId,
            UserName = "admin@123.com",
            Email = "admin@123.com",
            NormalizedEmail = "ADMIN@123.COM",
            NormalizedUserName = "ADMIN@123.COM"
        };

        admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

        var adminRoles = new List<IdentityUserRole<string>>
        {
            new() { UserId = adminUserId, RoleId = readerRoleId },
            new() { UserId = adminUserId, RoleId = writerRoleId }
        };

        builder.Entity<IdentityRole>().HasData(roles);
        builder.Entity<IdentityUser>().HasData(admin);
        builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
    }
}
