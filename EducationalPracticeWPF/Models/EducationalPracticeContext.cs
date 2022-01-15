using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EducationalPracticeWPF.Models
{
    public class EducationalPracticeContext : DbContext
    {
        public EducationalPracticeContext()
        {
        }
        public EducationalPracticeContext(DbContextOptions<EducationalPracticeContext> options) : base(options)
        {
        }

        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ProductsInReceipt> ProductsInReceipts { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = DatabaseManager.GetConnectionString();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasIndex(e => e.Naming, "UQ_Color_Naming")
                    .IsUnique();

                entity.Property(e => e.Naming)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Phone, "UQ_Customer_Phone")
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => new { e.PassportSeries, e.PassportNumber }, "UQ_Employee_Passport")
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("INN");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Name");

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("Passport_Number");

                entity.Property(e => e.PassportSeries)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Passport_Series");

                entity.Property(e => e.PostId).HasColumnName("Post_Id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Posts");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("Payment_Methods");

                entity.HasIndex(e => e.Naming, "UQ_Payment_Method_Naming")
                    .IsUnique();

                entity.Property(e => e.Naming)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.Naming, "UQ_Post_Post_Name")
                    .IsUnique();

                entity.Property(e => e.Naming)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((13890.00))");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Naming, "UQ_Product_Naming")
                    .IsUnique();

                entity.Property(e => e.ColorId).HasColumnName("Color_Id");

                entity.Property(e => e.Naming)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductTypeId).HasColumnName("Product_Type_Id");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Color_Id");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Product_Type_Id");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("Product_Types");

                entity.HasIndex(e => e.Naming, "UQ_Product_Type_Naming")
                    .IsUnique();

                entity.Property(e => e.Naming)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductsInReceipt>(entity =>
            {
                entity.ToTable("Products_In_Receipts");

                entity.Property(e => e.ProductCount)
                    .HasColumnName("Product_Count")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ReceiptId).HasColumnName("Receipt_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsInReceipts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_In_Receipt_Product_Id");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.ProductsInReceipts)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_In_Receipt_Receipt_Id");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_Method_Id");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("date")
                    .HasColumnName("Registration_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalSum)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total_Sum");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt_Customer_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt_Employee_Id");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt_Payment_Method_Id");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}