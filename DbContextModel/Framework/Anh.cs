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
        public int MaAnh { get; set; }

        [Required]
        [StringLength(300)]
        public string DuongDan { get; set; }

        public int? MaTin { get; set; }

        public virtual ThongTinBDS ThongTinBDS { get; set; }
    }
}
