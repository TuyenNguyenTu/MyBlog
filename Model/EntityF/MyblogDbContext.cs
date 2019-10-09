namespace Model.EntityF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyblogDbContext : DbContext
    {
        public MyblogDbContext()
            : base("name=Myblog_Connection")
        {
        }

        public virtual DbSet<tbl_AboutMe> tbl_AboutMe { get; set; }
        public virtual DbSet<tbl_CategoriesPosts> tbl_CategoriesPosts { get; set; }
        public virtual DbSet<tbl_FeedBack> tbl_FeedBack { get; set; }
        public virtual DbSet<tbl_Footer> tbl_Footer { get; set; }
        public virtual DbSet<tbl_ImagePosts> tbl_ImagePosts { get; set; }
        public virtual DbSet<tbl_Menu> tbl_Menu { get; set; }
        public virtual DbSet<tbl_Posts> tbl_Posts { get; set; }
        public virtual DbSet<tbl_Slide> tbl_Slide { get; set; }
        public virtual DbSet<tbl_TypeMenu> tbl_TypeMenu { get; set; }
        public virtual DbSet<tbl_UserName> tbl_UserName { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_CategoriesPosts>()
                .HasMany(e => e.tbl_Posts)
                .WithOptional(e => e.tbl_CategoriesPosts)
                .HasForeignKey(e => e.CategoriesID);

            modelBuilder.Entity<tbl_FeedBack>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Posts>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Posts>()
                .HasMany(e => e.tbl_ImagePosts)
                .WithRequired(e => e.tbl_Posts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_TypeMenu>()
                .HasMany(e => e.tbl_Menu)
                .WithOptional(e => e.tbl_TypeMenu)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<tbl_UserName>()
                .Property(e => e.UserName)
                .IsFixedLength();
        }
    }
}
