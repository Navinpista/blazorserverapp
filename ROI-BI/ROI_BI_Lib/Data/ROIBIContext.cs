using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ROI_BI_Lib.Models;

namespace ROI_BI_Lib.Data
{
    public partial class ROIBIContext : DbContext
    {
        public ROIBIContext()
        {
        }

        public ROIBIContext(DbContextOptions<ROIBIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Roimenu> Roimenus { get; set; } = null!;
        public virtual DbSet<Roireport> Roireports { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roimenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("ROIMenu");

                entity.Property(e => e.Css).HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IconName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NavigateUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roireport>(entity =>
            {
                entity.ToTable("ROIReport");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(250)
                    .HasColumnName("ClientID");

                entity.Property(e => e.ClientSecret).HasMaxLength(250);

                entity.Property(e => e.ReportId)
                    .HasMaxLength(250)
                    .HasColumnName("reportId");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenantId)
                    .HasMaxLength(250)
                    .HasColumnName("TenantID");

                entity.Property(e => e.WorkspaceId)
                    .HasMaxLength(250)
                    .HasColumnName("workspaceId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
