using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace demo2.Models;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productcategory> Productcategories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;database=demo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.23-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Delivid).HasName("PRIMARY");

            entity.ToTable("deliveries");

            entity.Property(e => e.Delivid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("delivid");
            entity.Property(e => e.Delivname)
                .HasMaxLength(45)
                .HasColumnName("delivname");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Manufid).HasName("PRIMARY");

            entity.ToTable("manufacturers");

            entity.Property(e => e.Manufid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("manufid");
            entity.Property(e => e.Manufname)
                .HasMaxLength(45)
                .HasColumnName("manufname");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productarticul).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.Proudctcategory, "category_idx");

            entity.HasIndex(e => e.Productdelivid, "deliv_idx");

            entity.HasIndex(e => e.Productmanufid, "manuf_idx");

            entity.Property(e => e.Productarticul)
                .HasMaxLength(100)
                .HasColumnName("productarticul");
            entity.Property(e => e.Productcount)
                .HasColumnType("int(11)")
                .HasColumnName("productcount");
            entity.Property(e => e.Productdelivid)
                .HasColumnType("int(11)")
                .HasColumnName("productdelivid");
            entity.Property(e => e.Productdescription)
                .HasColumnType("text")
                .HasColumnName("productdescription");
            entity.Property(e => e.Productdiscount)
                .HasPrecision(10, 2)
                .HasColumnName("productdiscount");
            entity.Property(e => e.Productimage)
                .HasColumnType("text")
                .HasColumnName("productimage");
            entity.Property(e => e.Productmanufid)
                .HasColumnType("int(11)")
                .HasColumnName("productmanufid");
            entity.Property(e => e.Productmaxdiscount)
                .HasPrecision(10, 2)
                .HasColumnName("productmaxdiscount");
            entity.Property(e => e.Productname)
                .HasMaxLength(45)
                .HasColumnName("productname");
            entity.Property(e => e.Productprice)
                .HasPrecision(10, 2)
                .HasColumnName("productprice");
            entity.Property(e => e.Productunit)
                .HasMaxLength(45)
                .HasColumnName("productunit");
            entity.Property(e => e.Proudctcategory)
                .HasColumnType("int(11)")
                .HasColumnName("proudctcategory");

            entity.HasOne(d => d.Productdeliv).WithMany(p => p.Products)
                .HasForeignKey(d => d.Productdelivid)
                .HasConstraintName("deliv");

            entity.HasOne(d => d.Productmanuf).WithMany(p => p.Products)
                .HasForeignKey(d => d.Productmanufid)
                .HasConstraintName("manuf");

            entity.HasOne(d => d.ProudctcategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Proudctcategory)
                .HasConstraintName("category");
        });

        modelBuilder.Entity<Productcategory>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("PRIMARY");

            entity.ToTable("productcategory");

            entity.Property(e => e.Categoryid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(45)
                .HasColumnName("categoryname");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Roleid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(45)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Userroleid, "rolid_idx");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("userid");
            entity.Property(e => e.Userlogin)
                .HasMaxLength(45)
                .HasColumnName("userlogin");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(45)
                .HasColumnName("userpassword");
            entity.Property(e => e.Userpatronymic)
                .HasMaxLength(45)
                .HasColumnName("userpatronymic");
            entity.Property(e => e.Userroleid)
                .HasColumnType("int(11)")
                .HasColumnName("userroleid");
            entity.Property(e => e.Usersurname)
                .HasMaxLength(45)
                .HasColumnName("usersurname");

            entity.HasOne(d => d.Userrole).WithMany(p => p.Users)
                .HasForeignKey(d => d.Userroleid)
                .HasConstraintName("rolid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
