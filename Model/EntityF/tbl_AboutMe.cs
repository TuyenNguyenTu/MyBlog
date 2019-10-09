namespace Model.EntityF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AboutMe
    {
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name ="Họ")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [StringLength(250)]
        [Display(Name = "Meta Title")]
        public string MetaTitle { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Giới thiệu")]
        public string Introduce { get; set; }

        [StringLength(500)]
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
    }
}
