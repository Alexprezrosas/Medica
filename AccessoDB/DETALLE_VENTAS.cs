namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_VENTAS
    {
        [Key]
        public int ID_DETALLE_VENTA { get; set; }

        public int VENTAID { get; set; }

        public int MEDICAMENTOID { get; set; }

        public int CANTIDAD { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? F_CADUCIDAD { get; set; }

        [StringLength(10)]
        public string NOMMEDICAMENTO { get; set; }

        public decimal? SUBTOTAL { get; set; }

        public virtual CATALOGO_MEDICAMENTOS CATALOGO_MEDICAMENTOS { get; set; }

        public virtual VENTAS_GENERALES VENTAS_GENERALES { get; set; }
    }
}
