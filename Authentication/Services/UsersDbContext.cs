﻿using AuthenticationService.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Services;

public class UsersDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }
}
