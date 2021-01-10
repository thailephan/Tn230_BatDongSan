namespace DbContextModel.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anh")]
    public partial class Anh
    {
        [Key]
        [Display(Name = "Mã ảnh")]
        public int MaAnh { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Đường dẫn")]
        public string DuongDan { get; set; }
        [Display(Name = "Mã tin")]
        public int? MaTin { get; set; }

        public virtual ThongTinBDS ThongTinBDS { get; set; }
    }
}
