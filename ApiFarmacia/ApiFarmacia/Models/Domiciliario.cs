namespace ApiFarmacia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Domiciliario")]
    public partial class Domiciliario
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column("Domiciliario", Order = 1)]
        [StringLength(50)]
        public string Domiciliario1 { get; set; }
    }
}
