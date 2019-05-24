using System;
using Erp_Biscuiterie_Back.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Erp_Biscuiterie_Back.Business.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientDisponibily> IngredientDisponibily { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDisponibility> ProductDisponibility { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Reduction> Reduction { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<TypeIngredient> TypeIngredient { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=8889;User Id=root;Password=root;Database=biscuiterie");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.ReductionId)
                    .HasName("ReductionId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DepartmentName).HasColumnType("varchar(255)");

                entity.Property(e => e.DirectorName).HasColumnType("varchar(255)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ReductionId).HasColumnType("int(11)");

                entity.HasOne(d => d.Reduction)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.ReductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_ibfk_1");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasIndex(e => e.TypeIngredientId)
                    .HasName("TypeIngredientId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TypeIngredientId).HasColumnType("int(11)");

                entity.HasOne(d => d.TypeIngredient)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.TypeIngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ingredient_ibfk_1");
            });

            modelBuilder.Entity<IngredientDisponibily>(entity =>
            {
                entity.HasIndex(e => e.IngredientId)
                    .HasName("IngredientId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IngredientId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.IngredientDisponibily)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ingredientdisponibily_ibfk_1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomerId");

                entity.HasIndex(e => e.StateId)
                    .HasName("StateId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.StateId).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_ibfk_2");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_ibfk_1");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("OrderId");

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderdetails_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderdetails_ibfk_2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<ProductDisponibility>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDisponibility)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productdisponibility_ibfk_1");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasIndex(e => e.IngredientId)
                    .HasName("IngredientId");

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IngredientId).HasColumnType("int(11)");

                entity.Property(e => e.IngredientQuantity).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_ibfk_2");
            });

            modelBuilder.Entity<Reduction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TypeIngredient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Divider).HasColumnType("int(11)");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId).HasColumnType("int(11)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");
            });
        }
    }
}
