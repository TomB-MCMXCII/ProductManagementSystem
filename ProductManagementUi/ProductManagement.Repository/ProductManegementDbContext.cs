using Microsoft.EntityFrameworkCore;
using ProductManegement.Core.Interfaces;
using ProductManegement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Repository
{
    public class ProductManagementDbContext : DbContext, IProductManagementDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectAudit> ProjectAudits { get; set; }

        public ProductManagementDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
