    using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstWebReact.Model;
public partial class DataUserContext : DbContext
{

    public DataUserContext()
    {
    }

    public DataUserContext(DbContextOptions<DataUserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vipmembership> Vipmemberships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=DataUser;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58925CB1D8");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreditCardNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cvv)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CVV");
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Payments__UserID__3A81B327");
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B71E22B4E");

            entity.ToTable("TransactionHistory");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.Details).HasColumnType("text");
            entity.Property(e => e.TransactionDate)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Transacti__UserI__46E78A0C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACFD5F11EA");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4DE70E726").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105344993BA9E").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vipmembership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__VIPMembe__92A7859980FF3514");

            entity.ToTable("VIPMemberships");

            entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.MembershipDetails).HasColumnType("text");
            entity.Property(e => e.MembershipType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Vipmemberships)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__VIPMember__UserI__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
