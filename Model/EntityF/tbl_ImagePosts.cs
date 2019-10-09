namespace Model.EntityF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ImagePosts
    {
        [Key]
        [Column(Order = 0)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Images { get; set; }

        [StringLength(50)]
        public string AltForImage { get; set; }

        public bool? Status { get; set; }

        public virtual tbl_Posts tbl_Posts { get; set; }
    }
}
