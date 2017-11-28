namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PropertyDbContext : DbContext
    {
        public PropertyDbContext()
            : base("name=PropertyDbContext")
        {
        }

        public virtual DbSet<DISTRICT> DISTRICTs { get; set; }
        public virtual DbSet<FEATURE> FEATUREs { get; set; }
        public virtual DbSet<PROJECT_STATUS> PROJECT_STATUS { get; set; }
        public virtual DbSet<PROPERTY> PROPERTies { get; set; }
        public virtual DbSet<PROPERTY_FEATURE> PROPERTY_FEATURE { get; set; }
        public virtual DbSet<PROPERTY_TYPE> PROPERTY_TYPE { get; set; }
        public virtual DbSet<STREET> STREETs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<WARD> WARDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DISTRICT>()
                .HasMany(e => e.PROPERTies)
                .WithOptional(e => e.DISTRICT)
                .HasForeignKey(e => e.District_ID);

            modelBuilder.Entity<DISTRICT>()
                .HasMany(e => e.STREETs)
                .WithOptional(e => e.DISTRICT)
                .HasForeignKey(e => e.District_ID);

            modelBuilder.Entity<DISTRICT>()
                .HasMany(e => e.WARDs)
                .WithOptional(e => e.DISTRICT)
                .HasForeignKey(e => e.District_ID);

            modelBuilder.Entity<FEATURE>()
                .HasMany(e => e.PROPERTY_FEATURE)
                .WithOptional(e => e.FEATURE)
                .HasForeignKey(e => e.Feature_ID);

            modelBuilder.Entity<PROJECT_STATUS>()
                .HasMany(e => e.PROPERTies)
                .WithOptional(e => e.PROJECT_STATUS)
                .HasForeignKey(e => e.Status_ID);

            modelBuilder.Entity<PROPERTY>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<PROPERTY>()
                .Property(e => e.Images)
                .IsUnicode(false);

            modelBuilder.Entity<PROPERTY>()
                .HasMany(e => e.PROPERTY_FEATURE)
                .WithOptional(e => e.PROPERTY)
                .HasForeignKey(e => e.Property_ID);

            modelBuilder.Entity<PROPERTY_TYPE>()
                .Property(e => e.CodeType)
                .IsUnicode(false);

            modelBuilder.Entity<PROPERTY_TYPE>()
                .HasMany(e => e.PROPERTies)
                .WithOptional(e => e.PROPERTY_TYPE)
                .HasForeignKey(e => e.PropertyType_ID);

            modelBuilder.Entity<STREET>()
                .HasMany(e => e.PROPERTies)
                .WithOptional(e => e.STREET)
                .HasForeignKey(e => e.Street_ID);

            modelBuilder.Entity<USER>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.PROPERTies)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.PROPERTies1)
                .WithOptional(e => e.USER1)
                .HasForeignKey(e => e.Sale_ID);

            modelBuilder.Entity<WARD>()
                .HasMany(e => e.PROPERTies)
                .WithOptional(e => e.WARD)
                .HasForeignKey(e => e.Ward_ID);
        }
    }
}
