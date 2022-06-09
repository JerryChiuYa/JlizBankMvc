﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using JlizBankEntity.JlizEntity;

namespace JlizBankEntity.JlizContext
{
    public partial class JlizBankContext : DbContext
    {
        public JlizBankContext()
        {
        }

        public JlizBankContext(DbContextOptions<JlizBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<BankPersonalInfo> BankPersonalInfo { get; set; }
        public virtual DbSet<BranchBank> BranchBank { get; set; }
        public virtual DbSet<TransactionRecordsDetails> TransactionRecordsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.AccountNum)
                    .HasName("PK__BankAcco__3ABF981742030B7E");

                entity.Property(e => e.AccountNum)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccountBalance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BankId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HashPassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InitDate).HasColumnType("datetime");

                entity.Property(e => e.LoginAccount)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.BankAccount)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankAccount_BranchBank");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BankAccount)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankAccount_BankPersonalInfo");
            });

            modelBuilder.Entity<BankPersonalInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__BankPers__3ABF9817FA148F34");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.IdentityNum)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InitDate).HasColumnType("datetime");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<BranchBank>(entity =>
            {
                entity.HasKey(e => e.BankId)
                    .HasName("PK__BranchBa__AA08CB13E2151C9B");

                entity.Property(e => e.BankId)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.InitDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TransactionRecordsDetails>(entity =>
            {
                entity.HasKey(e => e.TransactionNum)
                    .HasName("PK__Transact__D2A40C257CF1A393");

                entity.Property(e => e.TransactionNum).ValueGeneratedNever();

                entity.Property(e => e.AccountBalance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FromAccountNum)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FromBankId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FromBankName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HandlingFees).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.Property(e => e.ToAccountNum)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ToBankId)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ToBankName).HasMaxLength(20);

                entity.Property(e => e.TransactionMoney).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TransactionTime).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}