namespace Model.EntityF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CategoriesPosts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_CategoriesPosts()
        {
            tbl_Posts = new HashSet<tbl_Posts>();
        }
        [Display(Name = "Mã")]
        public long ID { get; set; }

        [StringLength(200)]
        [Display(Name = "Tên loại")]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string MetaTitle { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime? CratedDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Posts> tbl_Posts { get; set; }
    }
}
