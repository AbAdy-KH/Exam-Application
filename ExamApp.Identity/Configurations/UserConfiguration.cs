﻿using ExamApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "admin@localhost.com",
                     NormalizedUserName = "ADMIN@LOCALHOST.COM",
                     PasswordHash = "AQAAAAEAACcQAAAAEL+xakUAp98NGnH0Vm1RZBz0YpMCxEi+qI1oyO8zZVZz4a5mL0EmWqU71re6iYQdrg==",
                     EmailConfirmed = true,
                     SecurityStamp = "STATIC-SECURITY-STAMP-ADMIN",
                     ConcurrencyStamp = "STATIC-CONCURRENCY-STAMP-ADMIN"
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user@localhost.com",
                     NormalizedUserName = "USER@LOCALHOST.COM",
                     PasswordHash = "AQAAAAEAACcQAAAAEL+xakUAp98NGnH0Vm1RZBz0YpMCxEi+qI1oyO8zZVZz4a5mL0EmWqU71re6iYQdrg==",
                     EmailConfirmed = true,
                     SecurityStamp = "STATIC-SECURITY-STAMP-ADMIN",
                     ConcurrencyStamp = "STATIC-CONCURRENCY-STAMP-ADMIN"
                 }
            );
        }
    }
}
