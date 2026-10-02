using Microsoft.EntityFrameworkCore;
using InventarioWebBE_FullStack.Models;
namespace InventarioWebBE_FullStack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Brand> Brand => Set<Brand>();
        public DbSet<DocumentType> DocumentType => Set<DocumentType>();

        public DbSet<InvoicePurchase> InvoicePurchase => Set<InvoicePurchase>();

        public DbSet<InvoiceSold> InvoiceSold => Set<InvoiceSold>();

        public DbSet<LostProduct> LostProduct => Set<LostProduct>();

        public DbSet<PriceBought> PriceBought => Set<PriceBought>();

        public DbSet<PriceMargin> PriceMargin => Set<PriceMargin>();

        public DbSet<PriceTag> PriceTag => Set<PriceTag>();

        public DbSet<Product> Product => Set<Product>();

        public DbSet<PurchaseOrder> PurchaseOrder => Set<PurchaseOrder>();

        public DbSet<SellingOrder> SellingOrder => Set<SellingOrder>();

        public DbSet<SoldProduct> SoldProduct => Set<SoldProduct>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Brand>()
                .HasIndex(b => b.ID).IsUnique();


            modelBuilder.Entity<DocumentType>()
                .HasIndex(b => b.ID).IsUnique();


            modelBuilder.Entity<InvoicePurchase>()
                .HasIndex(b => b.ID).IsUnique();
            modelBuilder.Entity<InvoicePurchase>()
                .Property(c => c.PriceTotal).HasPrecision(12, 2);
           modelBuilder.Entity<InvoicePurchase>()
               .Property(d => d.TaxTotal).HasPrecision(12, 2);
            modelBuilder.Entity<InvoicePurchase>()
               .Property(e => e.ShippingCost).HasPrecision(12, 2);



            modelBuilder.Entity<InvoiceSold>()
                .HasIndex(b => b.ID).IsUnique();
            modelBuilder.Entity<InvoiceSold>()
                .Property(c => c.PriceTotal).HasPrecision(12, 2);
            modelBuilder.Entity<InvoiceSold>()
                .Property(d => d.ShippingCost).HasPrecision(12, 2);
            modelBuilder.Entity<InvoiceSold>()
                .Property(e => e.TaxTotal).HasPrecision(12, 2);



            modelBuilder.Entity<LostProduct>()
                .HasIndex(b => b.ID).IsUnique();
            //public int Quantity { get; set; } >0


            modelBuilder.Entity<PriceBought>()
                .HasIndex(b => b.ID).IsUnique();
            modelBuilder.Entity<PriceBought>()
                .Property(c=> c.UnitPrice).HasPrecision(12,2);
            modelBuilder.Entity<PriceBought>()
                .Property(d=>d.ShippingCost) .HasPrecision(12,2);



            modelBuilder.Entity<PriceMargin>()
                .HasIndex(b => b.ID).IsUnique();


            modelBuilder.Entity<PriceTag>()
                .HasIndex(b => b.ID).IsUnique();
            modelBuilder.Entity<PriceTag>()
                .Property(c=> c.Pricetag).HasPrecision(12, 2);
            modelBuilder.Entity<PriceTag>()
                .Property(d=>d.TotalCosts).HasPrecision(12, 2);
            


            modelBuilder.Entity<Product>()
                .HasIndex(b => b.ID).IsUnique();
            //public int Quantity { get; set; } >0




            modelBuilder.Entity<PurchaseOrder>()
                .HasIndex(b => b.ID).IsUnique();
            modelBuilder.Entity<PurchaseOrder>()
                .Property(c=>c.Taxes).HasPrecision(12, 2);
            modelBuilder.Entity<PurchaseOrder>()
                .Property(d=>d.ShippingCost).HasPrecision(12, 2);
            modelBuilder.Entity<PurchaseOrder>()
                .Property(e=>e.Taxes).HasPrecision(12, 2);



            modelBuilder.Entity<SellingOrder>()
                .HasIndex(b => b.ID).IsUnique();
            modelBuilder.Entity<SellingOrder>()
                .Property(c=>c.TotalPrice).HasPrecision(12, 2);
            modelBuilder.Entity<SellingOrder>()
                .Property(d => d.ShippingCost).HasPrecision (12, 2);
            modelBuilder.Entity<SellingOrder>()
                .Property(e=>e.Taxes) .HasPrecision(12, 2);
            modelBuilder.Entity<SellingOrder>()
                .Property(f=>f.Profit).HasPrecision(12, 2);





            modelBuilder.Entity<SoldProduct>()
                .HasIndex(b => b.ID).IsUnique();
            modelBuilder.Entity<SoldProduct>()
                .Property(c=>c.ShippingCost) .HasPrecision(12, 2);
            modelBuilder.Entity<SoldProduct>()
                .Property(d => d.Taxes).HasPrecision(12, 2);
            modelBuilder.Entity<SoldProduct>()
                .Property(e=>e.ShippingCost).HasPrecision(12, 2);
            modelBuilder.Entity<SoldProduct>()
                .Property(f=>f.Profit).HasPrecision(12, 2);
            //public int Quantity { get; set; } >0



        }

    }
}
