    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectFinal.Areas.Admin.Models;
using ProjectFinal.Models;
using ProjectFinal.Models.Courier;
using ProjectFinal.Models.Invoices;
using ProjectFinal.Models.MakeOrder;
using ProjectFinal.Models.PanelPage;
using ProjectFinal.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.DataConnect
{
    public class DbContextApp : IdentityDbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp> options)
            : base(options)
        {

        }


        //======================== CONFIGURATION FOR MANY TO MANY TABLE BETWEEN INVOICES AND COURIER ORDERS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourierDbViewModelInvoice>()
                .HasKey(bc => new { bc.InvoiceId, bc.CourierDbViewModelId });
            modelBuilder.Entity<CourierDbViewModelInvoice>()
                .HasOne(bc => bc.Invoice)
                .WithMany(b => b.CourierDbViewModelInvoices)
                .HasForeignKey(bc => bc.InvoiceId);
            modelBuilder.Entity<CourierDbViewModelInvoice>()
                .HasOne(bc => bc.CourierDbViewModel)
                .WithMany(c => c.CourierDbViewModelInvoices)
                .HasForeignKey(bc => bc.CourierDbViewModelId);
        }





        public DbSet<DbPassportUserModel> CustomUsers { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }
        public DbSet<HomeNews> HomeNews { get; set; }
        public DbSet<RulesAccardion> RulesAccardions { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<About> Abouts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<AccountBalanceViewModel> Balances { get; set; }
        public DbSet<CourierDbViewModel> CourierDeliveries { get; set; }
        public DbSet<CourierDbViewModelInvoice> CourierDbViewModelInvoices { get; set; }
        public DbSet<UserTransaction> Transactions { get; set; }
        public DbSet<LinkOrder> Orders { get; set; }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopContent> ShopContents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<addressesabroad>  Addressesabroads { get; set; }



    }
}
