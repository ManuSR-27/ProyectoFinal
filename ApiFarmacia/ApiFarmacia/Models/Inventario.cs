namespace ApiFarmacia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventario")]
    public partial class Inventario
    {
        [Key]
        public int Id { get; set; }

        
        [StringLength(50)]
        public string CodigoProducto { get; set; }

        [StringLength(50)]
        public string NombreProducto { get; set; }

        [StringLength(50)]
        public string Concentracion { get; set; }

        [StringLength(50)]
        public string Presentacion { get; set; }

        [StringLength(50)]
        public string FechaInventario { get; set; }

        [StringLength(50)]
        public string NoEstante { get; set; }

        [StringLength(500)]
        public string FechaVencimiento { get; set; }

        [StringLength(50)]
        public string Cantidad { get; set; }
    }
}
