using CommonLayer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class AuthenticationContext :IdentityDbContext      
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AdminModel> ApplicationUser { get; set; }
    }

}
