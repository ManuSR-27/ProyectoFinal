namespace ApiFarmacia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Domicilio")]
    public partial class Domicilio
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [StringLength(50)]
        public string NombreProducto { get; set; }

        [StringLength(50)]
        public string Concentracion { get; set; }

        [StringLength(50)]
        public string Presentacion { get; set; }

        [StringLength(50)]
        public string CodigoProducto { get; set; }


        [StringLength(50)]
        public string Cantidad { get; set; }


        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [StringLength(50)]
        public string ApellidosUsuario { get; set; }


        [StringLength(50)]
        public string IdUsuario { get; set; }


        [StringLength(50)]
        public string Direccion { get; set; }


        [StringLength(50)]
        public string Barrio { get; set; }


        [StringLength(50)]
        public string Telefono { get; set; }


        [StringLength(50)]
        public string Domiciliario { get; set; }
    }
}
