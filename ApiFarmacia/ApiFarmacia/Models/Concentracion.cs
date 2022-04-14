namespace ApiFarmacia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Concentracion")]
    public partial class Concentracion
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column("Concentracion", Order = 1)]
        [StringLength(50)]
        public string Concentracion1 { get; set; }
    }
}
