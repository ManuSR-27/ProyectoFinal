namespace ApiFarmacia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recurso")]
    public partial class Recurso
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column("Recurso", Order = 1)]
        [StringLength(50)]
        public string Recurso1 { get; set; }
    }
}
