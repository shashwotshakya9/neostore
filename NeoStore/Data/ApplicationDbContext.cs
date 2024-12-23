using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NeoStore.Models;

namespace NeoStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NeoStore.Models.Category> Category { get; set; }
        public DbSet<NeoStore.Models.Customer> Customer { get; set; }
        public DbSet<NeoStore.Models.Product> Product { get; set; }
        public DbSet<NeoStore.Models.Stock> Stock { get; set; }
        public DbSet<NeoStore.Models.Sale> Sale { get; set; }
        public DbSet<NeoStore.Models.SaleDetail> SaleDetail { get; set; }
        public DbSet<NeoStore.Models.Purchase> Purchase { get; set; }
        public DbSet<NeoStore.Models.PurchaseDetail> PurchaseDetail { get; set; }
    }
}
