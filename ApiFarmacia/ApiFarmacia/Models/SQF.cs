namespace ApiFarmacia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SQF")]
    public partial class SQF
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        
        [Column(Order = 1)]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Column(Order = 3)]
        [StringLength(50)]
        public string Identificacion { get; set; }

        [Column(Order = 4)]
        [StringLength(50)]
        public string Telefono { get; set; }

        [Column(Order = 5)]
        [StringLength(50)]
        public string Barrio { get; set; }

        [Column(Order = 6)]
        [StringLength(500)]
        public string Email { get; set; }

        [Column(Order = 7)]
        [StringLength(50)]
        public string Recurso { get; set; }

        [Column(Order = 8)]
        [StringLength(500)]
        public string Fecha { get; set; }

        [Column(Order = 9)]
        [StringLength(500)]
        public string Situacion { get; set; }
    }
}
