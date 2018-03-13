namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VENTAS_GENERALES
    {
        [Key]
        public int ID_VENTA_GEBNERAL { get; set; }

        public int DETALLE_VENTAID { get; set; }

        public decimal? TOTAL { get; set; }

        public decimal? IMPORTE { get; set; }

        public decimal? IVA { get; set; }

        public decimal? DESCUENTO { get; set; }

        public int UDUARIOID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual DETALLE_VENTAS DETALLE_VENTAS { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
