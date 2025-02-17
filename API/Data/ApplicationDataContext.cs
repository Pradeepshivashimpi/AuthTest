using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDataContext : DbContext
{
   public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
   {
    
   }

   public DbSet<Product> Products { get; set; }
}
