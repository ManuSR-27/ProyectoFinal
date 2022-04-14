namespace ApiFarmacia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Presentacion")]
    public partial class Presentacion
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column("Presentacion", Order = 1)]
        [StringLength(50)]
        public string Presentacion1 { get; set; }
    }
}
