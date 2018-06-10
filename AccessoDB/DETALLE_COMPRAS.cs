namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_COMPRAS
    {
        [Key]
        public int ID_DETALLE_COMPRA { get; set; }

        public int COMPRAID { get; set; }

        public int MEDICAMENTOID { get; set; }

        public int CANTIDAD { get; set; }

        public decimal? COSTO_UNITARIO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [StringLength(100)]
        public string U_MEDIDA { get; set; }

        public int? CFDI { get; set; }

        public decimal? SUBTOTAL { get; set; }

        [StringLength(50)]
        public string ALMACEN { get; set; }

        [StringLength(100)]
        public string NOMEDI { get; set; }

        public virtual CATALOGO_MEDICAMENTOS CATALOGO_MEDICAMENTOS { get; set; }

        public virtual COMPRA COMPRA { get; set; }
    }
}
