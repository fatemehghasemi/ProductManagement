using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductAdt> ProductAdts => Set<ProductAdt>();
    public DbSet<ProductAdtType> ProductAdtTypes => Set<ProductAdtType>();
    public DbSet<ProductAdtPrice> ProductAdtPrices => Set<ProductAdtPrice>();
    public DbSet<ProductDeliver> ProductDelivers => Set<ProductDeliver>();
    public DbSet<ProductDeliverSize> ProductDeliverSizes => Set<ProductDeliverSize>();
    public DbSet<ProductMaterial> ProductMaterials => Set<ProductMaterial>();
    public DbSet<ProductMaterialAttribute> ProductMaterialAttributes => Set<ProductMaterialAttribute>();
    public DbSet<ProductSize> ProductSizes => Set<ProductSize>();
    public DbSet<ProductPrintKind> ProductPrintKinds => Set<ProductPrintKind>();
    public DbSet<ProductPrice> ProductPrices => Set<ProductPrice>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Sizes)
            .WithOne(s => s.Product)
            .HasForeignKey(s => s.ProductId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Materials)
            .WithOne(m => m.Product)
            .HasForeignKey(m => m.ProductId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Adts)
            .WithOne(a => a.Product)
            .HasForeignKey(a => a.ProductId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Delivers)
            .WithOne(d => d.Product)
            .HasForeignKey(d => d.ProductId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.PrintKinds)
            .WithOne(pk => pk.Product)
            .HasForeignKey(pk => pk.ProductId);

        modelBuilder.Entity<ProductAdt>()
            .HasMany(pa => pa.Types)
            .WithOne(pat => pat.ProductAdt)
            .HasForeignKey(pat => pat.ProductAdtId);

        modelBuilder.Entity<ProductAdt>()
            .HasMany(pa => pa.Prices)
            .WithOne(pap => pap.ProductAdt)
            .HasForeignKey(pap => pap.ProductAdtId);

        modelBuilder.Entity<ProductDeliver>()
            .HasMany(pd => pd.Sizes)
            .WithOne(pds => pds.ProductDeliver)
            .HasForeignKey(pds => pds.ProductDeliverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductDeliverSize>()
            .HasOne(pds => pds.ProductSize)
            .WithMany(ps => ps.DeliverSizes)
            .HasForeignKey(pds => pds.ProductSizeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductMaterial>()
            .HasMany(pm => pm.Attributes)
            .WithOne(pma => pma.ProductMaterial)
            .HasForeignKey(pma => pma.ProductMaterialId);

        modelBuilder.Entity<ProductPrice>()
            .HasOne(pp => pp.ProductSize)
            .WithMany()
            .HasForeignKey(pp => pp.ProductSizeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductPrice>()
            .HasOne(pp => pp.ProductMaterial)
            .WithMany()
            .HasForeignKey(pp => pp.ProductMaterialId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductPrice>()
            .HasOne(pp => pp.ProductMaterialAttribute)
            .WithMany()
            .HasForeignKey(pp => pp.ProductMaterialAttributeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductPrice>()
            .HasOne(pp => pp.ProductPrintKind)
            .WithMany()
            .HasForeignKey(pp => pp.ProductPrintKindId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}