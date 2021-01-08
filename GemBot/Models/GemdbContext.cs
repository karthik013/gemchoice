using System;
using System.Reflection;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace GemBot.Models
{
    public partial class GemdbContext : DbContext
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public GemdbContext()
        {
        }

        public GemdbContext(DbContextOptions<GemdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GemBox> GemBox { get; set; }
        public virtual DbSet<GemCert> GemCert { get; set; }
        public virtual DbSet<GemClarity> GemClarity { get; set; }
        public virtual DbSet<GemColor> GemColor { get; set; }
        public virtual DbSet<GemColorShade> GemColorShade { get; set; }
        public virtual DbSet<GemCut> GemCut { get; set; }
        public virtual DbSet<GemFineshedType> GemFineshedType { get; set; }
        public virtual DbSet<GemMasterProducts> GemMasterProducts { get; set; }
        public virtual DbSet<GemOrigin> GemOrigin { get; set; }
        public virtual DbSet<GemParcelType> GemParcelType { get; set; }
        public virtual DbSet<GemProduct> GemProduct { get; set; }
        public virtual DbSet<GemRegisteration> GemRegisteration { get; set; }
        public virtual DbSet<GemShape> GemShape { get; set; }
        public virtual DbSet<GemSizeRange> GemSizeRange { get; set; }
        public virtual DbSet<GemTreatment> GemTreatment { get; set; }
        public virtual DbSet<GemType> GemType { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                string dbCon;
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                dbCon = config["Database:DbCon"];

                log.InfoFormat("Database Connection String {0}", dbCon);
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(dbCon);
                //optionsBuilder.UseSqlServer("Data Source=IN1LT1164\\SQLEXPRESS;Initial Catalog=Gemdb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GemBox>(entity =>
            {
                entity.ToTable("gemBox");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasViewColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Drawer)
                    .HasColumnName("drawer")
                    .HasViewColumnName("drawer")
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasViewColumnName("location")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.RefNo)
                    .HasColumnName("refNo")
                    .HasViewColumnName("refNo")
                    .HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GemCert>(entity =>
            {
                entity.ToTable("gemCert");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.GemCert)
                    .HasForeignKey(x => x.ProductId)
                    .HasConstraintName("FK_gemCert_GemMasterProducts");
            });

            modelBuilder.Entity<GemClarity>(entity =>
            {
                entity.ToTable("gemClarity");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Clarity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemColor>(entity =>
            {
                entity.ToTable("gemColor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasViewColumnName("color")
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemColorShade>(entity =>
            {
                entity.ToTable("gemColorShade");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GemColor)
                    .HasColumnName("gemColor")
                    .HasViewColumnName("gemColor");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.Shade)
                    .IsRequired()
                    .HasColumnName("shade")
                    .HasViewColumnName("shade")
                    .HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.GemColorNavigation)
                    .WithMany(p => p.GemColorShade)
                    .HasForeignKey(x => x.GemColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gemColorShade_gemColor");
            });

            modelBuilder.Entity<GemCut>(entity =>
            {
                entity.ToTable("gemCut");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cut)
                    .HasColumnName("cut")
                    .HasViewColumnName("cut")
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemFineshedType>(entity =>
            {
                entity.ToTable("gemFineshedType");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FineshedType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GemType)
                    .HasColumnName("gemType")
                    .HasViewColumnName("gemType")
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemMasterProducts>(entity =>
            {
                entity.HasKey(x => x.GeneratedRefId);

                entity.Property(e => e.GeneratedRefId).HasMaxLength(50);

                entity.Property(e => e.CDate)
                    .HasColumnName("C_Date")
                    .HasViewColumnName("C_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CaretWeight)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Clarity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cut)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DiscountCode).HasMaxLength(50);

                entity.Property(e => e.FinishType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GemType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsArchieved)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Isfeatured)
                    .HasColumnName("isfeatured")
                    .HasViewColumnName("isfeatured");

                entity.Property(e => e.LongDescription).IsRequired();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParcelType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PricePerCarat)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PricePerPiece).HasMaxLength(50);

                entity.Property(e => e.RefNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Shade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Shape)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortDescription).IsRequired();

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SizeRange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Treatment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("U_Date")
                    .HasViewColumnName("U_Date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GemOrigin>(entity =>
            {
                entity.ToTable("gemOrigin");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.Origin).HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemParcelType>(entity =>
            {
                entity.ToTable("gemParcelType");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.ParceType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GemProduct>(entity =>
            {
                entity.ToTable("gemProduct");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.Boxid)
                    .HasColumnName("boxid")
                    .HasViewColumnName("boxid")
                    .HasMaxLength(50);

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnName("discountAmount")
                    .HasViewColumnName("discountAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DiscountCode)
                    .HasColumnName("discountCode")
                    .HasViewColumnName("discountCode")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GemCarat)
                    .HasColumnName("gemCarat")
                    .HasViewColumnName("gemCarat")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GemClarity)
                    .HasColumnName("gemClarity")
                    .HasViewColumnName("gemClarity")
                    .HasMaxLength(50);

                entity.Property(e => e.GemColor)
                    .HasColumnName("gemColor")
                    .HasViewColumnName("gemColor")
                    .HasMaxLength(50);

                entity.Property(e => e.GemColorShade)
                    .HasColumnName("gemColorShade")
                    .HasViewColumnName("gemColorShade")
                    .HasMaxLength(50);

                entity.Property(e => e.GemCut)
                    .HasColumnName("gemCut")
                    .HasViewColumnName("gemCut")
                    .HasMaxLength(50);

                entity.Property(e => e.GemName)
                    .HasColumnName("gemName")
                    .HasViewColumnName("gemName")
                    .HasMaxLength(50);

                entity.Property(e => e.GemOrigin)
                    .HasColumnName("gemOrigin")
                    .HasViewColumnName("gemOrigin")
                    .HasMaxLength(50);

                entity.Property(e => e.GemPieces)
                    .HasColumnName("gemPieces")
                    .HasViewColumnName("gemPieces");

                entity.Property(e => e.GemPrice)
                    .HasColumnName("gemPrice")
                    .HasViewColumnName("gemPrice")
                    .HasMaxLength(50);

                entity.Property(e => e.GemShape)
                    .HasColumnName("gemShape")
                    .HasViewColumnName("gemShape")
                    .HasMaxLength(50);

                entity.Property(e => e.GemSizeRange)
                    .HasColumnName("gemSizeRange")
                    .HasViewColumnName("gemSizeRange")
                    .HasMaxLength(50);

                entity.Property(e => e.GemTreatment)
                    .HasColumnName("gemTreatment")
                    .HasViewColumnName("gemTreatment")
                    .HasMaxLength(50);

                entity.Property(e => e.GemType)
                    .HasColumnName("gemType")
                    .HasViewColumnName("gemType")
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.IsArchived)
                    .HasColumnName("isArchived")
                    .HasViewColumnName("isArchived");

                entity.Property(e => e.IsFeatured)
                    .HasColumnName("isFeatured")
                    .HasViewColumnName("isFeatured");

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .HasViewColumnName("orderid");

                entity.Property(e => e.PacketNo)
                    .HasColumnName("packetNo")
                    .HasViewColumnName("packetNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Parceid)
                    .HasColumnName("parceid")
                    .HasViewColumnName("parceid");

                entity.Property(e => e.PicProfile)
                    .HasColumnName("picProfile")
                    .HasViewColumnName("picProfile")
                    .HasMaxLength(50);

                entity.Property(e => e.PicSide)
                    .HasColumnName("picSide")
                    .HasViewColumnName("picSide")
                    .HasMaxLength(50);

                entity.Property(e => e.PicTop)
                    .HasColumnName("picTop")
                    .HasViewColumnName("picTop")
                    .HasMaxLength(50);

                entity.Property(e => e.Picfront)
                    .HasColumnName("picfront")
                    .HasViewColumnName("picfront")
                    .HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasViewColumnName("video")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GemRegisteration>(entity =>
            {
                entity.HasKey(x => x.EmailId);

                entity.ToTable("gemRegisteration");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GemShape>(entity =>
            {
                entity.ToTable("gemShape");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.Shape)
                    .IsRequired()
                    .HasColumnName("shape")
                    .HasViewColumnName("shape")
                    .HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemSizeRange>(entity =>
            {
                entity.ToTable("gemSizeRange");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.GemShapeNavigation)
                    .WithMany(p => p.GemSizeRange)
                    .HasForeignKey(x => x.GemShape)
                    .HasConstraintName("FK_gemSizeRange_gemshape");
            });

            modelBuilder.Entity<GemTreatment>(entity =>
            {
                entity.ToTable("gemTreatment");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.Treatment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GemType>(entity =>
            {
                entity.ToTable("gemType");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasViewColumnName("isActive");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UDate)
                    .HasColumnName("uDate")
                    .HasViewColumnName("uDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shoppingCart");

                entity.Property(e => e.CDate)
                    .HasColumnName("cDate")
                    .HasViewColumnName("cDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cartid)
                    .HasColumnName("cartid")
                    .HasViewColumnName("cartid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasViewColumnName("productid");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasViewColumnName("quantity");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasViewColumnName("userid")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
