namespace Model.EntityF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Posts()
        {
            tbl_ImagePosts = new HashSet<tbl_ImagePosts>();
        }

        public long ID { get; set; }

        [StringLength(500)]
        [Display(Name ="Tiêu đề")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string ContentPost { get; set; }

        [StringLength(500)]
        public string MetaTitle { get; set; }

        public long? DisplayOrder { get; set; }
        [Display(Name ="Loại bài")]
        public long? CategoriesID { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày viết bài")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        public long? TagID { get; set; }

        public virtual tbl_CategoriesPosts tbl_CategoriesPosts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ImagePosts> tbl_ImagePosts { get; set; }
    }
}
