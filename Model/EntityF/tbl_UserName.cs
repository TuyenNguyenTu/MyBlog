namespace Model.EntityF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_UserName
    {
        public long ID { get; set; }

        [StringLength(200)]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string PassWord { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="Ngày chỉnh sửa")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name ="Người chỉnh sửa")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        [Display(Name = "Người quản trị")]
        public bool? IsAdmin { get; set; }
    }
}
