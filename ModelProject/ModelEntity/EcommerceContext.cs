using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ModelEntity.ModelEntity;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillItem> BillItems { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<BrandsCategory> BrandsCategorys { get; set; }

    public virtual DbSet<Category> Categorys { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DataProductInformation> DataProductInformations { get; set; }

    public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

    public virtual DbSet<IndustryInformation> IndustryInformations { get; set; }

    public virtual DbSet<IndustryInformationDetail> IndustryInformationDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductColor> ProductColors { get; set; }

    public virtual DbSet<ProductInformation> ProductInformations { get; set; }

    public virtual DbSet<ProductReview> ProductReviews { get; set; }

    public virtual DbSet<ProductVersion> ProductVersions { get; set; }

    public virtual DbSet<ProductVersionColor> ProductVersionColors { get; set; }

    public virtual DbSet<ProductsCategory> ProductsCategorys { get; set; }

    public virtual DbSet<Quantity> Quantitys { get; set; }

    public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }

    public virtual DbSet<WebRole> WebRoles { get; set; }

    public virtual DbSet<WebRoleUser> WebRoleUsers { get; set; }

    public virtual DbSet<WebUser> WebUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-5DKEKQQ7\\NGUYENTHINH;Initial Catalog=Ecommerce;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3214EC0710C41667");

            entity.Property(e => e.AccountName).HasMaxLength(256);
            entity.Property(e => e.AccountNumber).HasMaxLength(120);
            entity.Property(e => e.AccountType).HasMaxLength(120);
            entity.Property(e => e.BankName).HasMaxLength(256);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accounts__Custom__70DDC3D8");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bills__3214EC079124272D");

            entity.Property(e => e.AccountName).HasMaxLength(256);
            entity.Property(e => e.AccountNumber).HasMaxLength(120);
            entity.Property(e => e.AccountType).HasMaxLength(120);
            entity.Property(e => e.BankName).HasMaxLength(256);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveryStatus).HasMaxLength(256);
            entity.Property(e => e.IntoMoney).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IsCancel).HasDefaultValueSql("('False')");
            entity.Property(e => e.IsGiveAgift)
                .HasDefaultValueSql("('False')")
                .HasColumnName("IsGiveAGift");
            entity.Property(e => e.PaymentMethods).HasMaxLength(120);
            entity.Property(e => e.PaymentTime).HasColumnType("datetime");
            entity.Property(e => e.Promotion).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalAmountOfGiftPromotion).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bills)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bills__CustomerI__778AC167");
        });

        modelBuilder.Entity<BillItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillItem__3214EC07531CC8F3");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.IntoMoney).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IsPresent)
                .IsRequired()
                .HasDefaultValueSql("('False')");
            entity.Property(e => e.ProductImage).HasMaxLength(256);
            entity.Property(e => e.ProductName).HasMaxLength(256);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Promotion).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Bill).WithMany(p => p.BillItems)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillItems__BillI__7B5B524B");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brands__3214EC07BF8D3B40");

            entity.Property(e => e.BrandCode).HasMaxLength(256);
            entity.Property(e => e.BrandName).HasMaxLength(256);
            entity.Property(e => e.Brandimages)
                .HasMaxLength(256)
                .HasColumnName("brandimages");
            entity.Property(e => e.Brandlogo).HasMaxLength(256);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<BrandsCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BrandsCa__3213E83FAC48E9CC");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Brand).WithMany(p => p.BrandsCategories)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BrandsCat__Brand__3C69FB99");

            entity.HasOne(d => d.Category).WithMany(p => p.BrandsCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BrandsCat__Categ__3B75D760");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC079D3376C2");

            entity.Property(e => e.CategoryCode).HasMaxLength(1);
            entity.Property(e => e.CategoryImage).HasMaxLength(1);
            entity.Property(e => e.CategoryName).HasMaxLength(1);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.IsHot).HasDefaultValueSql("('False')");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07E14BE472");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerEmail).HasMaxLength(256);
            entity.Property(e => e.CustomerName).HasMaxLength(256);
            entity.Property(e => e.CustomerPhone).HasMaxLength(10);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Sex).HasMaxLength(100);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DataProductInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DataProd__3214EC07A79CB946");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DataProductInformationCode).HasMaxLength(256);
            entity.Property(e => e.DataProductInformationName).HasMaxLength(256);
            entity.Property(e => e.DataProductInformationValue).HasMaxLength(256);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DeliveryAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC076F950B2E");

            entity.ToTable("DeliveryAddress");

            entity.Property(e => e.City).HasMaxLength(256);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DetailedAddress).HasMaxLength(256);
            entity.Property(e => e.District).HasMaxLength(256);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Wards)
                .HasMaxLength(256)
                .HasColumnName("wards");
        });

        modelBuilder.Entity<IndustryInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Industry__3214EC07C9E8AEBF");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.IndustryInformationCode).HasMaxLength(256);
            entity.Property(e => e.IndustryInformationName).HasMaxLength(256);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.IndustryInformations)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IndustryI__Categ__6383C8BA");
        });

        modelBuilder.Entity<IndustryInformationDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Industry__3214EC074BA731B5");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DataProductInformationCode).HasMaxLength(256);
            entity.Property(e => e.IndustryInformationDetailCode).HasMaxLength(256);
            entity.Property(e => e.IndustryInformationDetailName).HasMaxLength(256);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.IndustryInformation).WithMany(p => p.IndustryInformationDetails)
                .HasForeignKey(d => d.IndustryInformationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IndustryI__Indus__68487DD7");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07C8A3D2C6");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('True')");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("('False')");
            entity.Property(e => e.IsHot).HasDefaultValueSql("('False')");
            entity.Property(e => e.IsNew).HasDefaultValueSql("('True')");
            entity.Property(e => e.Origin).HasMaxLength(256);
            entity.Property(e => e.PercentageReduction).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductCode).HasMaxLength(256);
            entity.Property(e => e.ProductName).HasMaxLength(256);
            entity.Property(e => e.ReleaseTime).HasColumnType("datetime");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SellNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasMany(d => d.Brands).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductBrand",
                    r => r.HasOne<Brand>().WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductBr__Brand__1332DBDC"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductBr__Produ__123EB7A3"),
                    j =>
                    {
                        j.HasKey("ProductId", "BrandId");
                        j.ToTable("ProductBrand");
                    });
        });

        modelBuilder.Entity<ProductColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3214EC07411490E2");

            entity.Property(e => e.ColorName).HasMaxLength(256);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ImageColorProduct).HasMaxLength(256);
            entity.Property(e => e.IsActive).HasDefaultValueSql("('True')");
            entity.Property(e => e.SellNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductColors)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCo__Produ__571DF1D5");
        });

        modelBuilder.Entity<ProductInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC07D5276C68");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ProductInformationValue).HasMaxLength(256);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.IndustryInformationDetail).WithMany(p => p.ProductInformations)
                .HasForeignKey(d => d.IndustryInformationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIn__Indus__6C190EBB");

            entity.HasOne(d => d.ProductVersion).WithMany(p => p.ProductInformations)
                .HasForeignKey(d => d.ProductVersionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIn__Produ__6B24EA82");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductR__3214EC079141A047");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerEmail).HasMaxLength(256);
            entity.Property(e => e.CustomerName).HasMaxLength(256);
            entity.Property(e => e.CustomerPhone).HasMaxLength(10);
            entity.Property(e => e.IsDelete).HasDefaultValueSql("('False')");
            entity.Property(e => e.IsEdit).HasDefaultValueSql("('False')");
            entity.Property(e => e.Productreview1).HasColumnName("Productreview");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__ProductRe__Custo__03F0984C");

            entity.HasOne(d => d.ProductVersion).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductVersionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRe__Produ__04E4BC85");
        });

        modelBuilder.Entity<ProductVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductV__3214EC073E523098");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('True')");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("('False')");
            entity.Property(e => e.IsHot).HasDefaultValueSql("('False')");
            entity.Property(e => e.IsNew).HasDefaultValueSql("('True')");
            entity.Property(e => e.PercentageReduction).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductVersionCode).HasMaxLength(256);
            entity.Property(e => e.ProductVersionName).HasMaxLength(256);
            entity.Property(e => e.ReleaseTime).HasColumnType("datetime");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SellNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVersions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductVe__Produ__52593CB8");
        });

        modelBuilder.Entity<ProductVersionColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductV__3214EC07E9401ECE");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ImageColorProduct).HasMaxLength(256);
            entity.Property(e => e.IsActive).HasDefaultValueSql("('True')");
            entity.Property(e => e.SellNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ProductVersion).WithMany(p => p.ProductVersionColors)
                .HasForeignKey(d => d.ProductVersionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductVe__Produ__5BE2A6F2");
        });

        modelBuilder.Entity<ProductsCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07F9124406");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductsCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductsC__Categ__45F365D3");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsCategories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductsC__Produ__46E78A0C");
        });

        modelBuilder.Entity<Quantity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quantity__3214EC070C4E0235");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Quantity1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Quantity");
            entity.Property(e => e.SellNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ProductVersionColor).WithMany(p => p.Quantities)
                .HasForeignKey(d => d.ProductVersionColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quantitys__Produ__60A75C0F");
        });

        modelBuilder.Entity<ShipmentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipment__3214EC07EDE65543");

            entity.Property(e => e.City).HasMaxLength(256);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(256);
            entity.Property(e => e.CustomerPhone).HasMaxLength(10);
            entity.Property(e => e.Delivery).HasMaxLength(120);
            entity.Property(e => e.DeliveryReviews).HasMaxLength(256);
            entity.Property(e => e.DeliveryStatus).HasMaxLength(120);
            entity.Property(e => e.DeliveryTime).HasColumnType("datetime");
            entity.Property(e => e.DetailedAddress).HasMaxLength(256);
            entity.Property(e => e.District).HasMaxLength(256);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Wards)
                .HasMaxLength(256)
                .HasColumnName("wards");

            entity.HasOne(d => d.Bill).WithMany(p => p.ShipmentDetails)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipmentD__BillI__7E37BEF6");

            entity.HasOne(d => d.Customer).WithMany(p => p.ShipmentDetails)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipmentD__Custo__7F2BE32F");
        });

        modelBuilder.Entity<WebRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WebRoles__3214EC07378B5A7A");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('True')");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("('False')");
            entity.Property(e => e.RoleCode).HasMaxLength(120);
            entity.Property(e => e.RoleDisPlay).HasMaxLength(256);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<WebRoleUser>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.UserId });

            entity.ToTable("WebRoleUser");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.WebRoleUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WebRoleUs__RoleI__2180FB33");

            entity.HasOne(d => d.User).WithMany(p => p.WebRoleUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WebRoleUs__UserI__208CD6FA");
        });

        modelBuilder.Entity<WebUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WebUsers__3214EC0711607FE0");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DisplayName).HasMaxLength(256);
            entity.Property(e => e.FullName).HasMaxLength(256);
            entity.Property(e => e.IsActive).HasDefaultValueSql("('True')");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("('False')");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserImage).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
