using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ROI_BI_Lib.Models
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

        public virtual DbSet<LoginAudit> LoginAudits { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuReport> MenuReports { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportAccess> ReportAccesses { get; set; }
        public virtual DbSet<ReportAudit> ReportAudits { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CIT-LP116\\SQLEXPRESS;Initial Catalog=ROIBI;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginAudit>(entity =>
            {
                entity.ToTable("LoginAudit");

                entity.Property(e => e.LoginMessage).HasMaxLength(200);

                entity.Property(e => e.LoginSessionId).HasMaxLength(100);

                entity.Property(e => e.LoginTime).HasColumnType("datetime");

                entity.Property(e => e.LogoutTime).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginAudits)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_LoginAudit_UserLogin");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sortorder).HasColumnName("sortorder");
            });

            modelBuilder.Entity<MenuReport>(entity =>
            {
                entity.ToTable("MenuReport");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuReports)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuReport1_Menu");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.MenuReports)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuReport1_Report");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.IsDashboard).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReportGuid).HasMaxLength(50);

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Report_Tenant");
            });

            modelBuilder.Entity<ReportAccess>(entity =>
            {
                entity.ToTable("ReportAccess");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ReportAudit>(entity =>
            {
                entity.HasKey(e => e.ReportAudit1);

                entity.ToTable("ReportAudit");

                entity.Property(e => e.ReportAudit1).HasColumnName("ReportAudit");

                entity.Property(e => e.AuditTime).HasColumnType("datetime");

                entity.Property(e => e.LoginSessionId).HasMaxLength(100);

                entity.Property(e => e.LoginSource)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReportId).HasMaxLength(50);
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenant");

                entity.Property(e => e.ClientGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientSecret)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenantGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkspaceGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserLogin");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
