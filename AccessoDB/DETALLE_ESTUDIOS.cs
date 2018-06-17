namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_ESTUDIOS
    {
        [Key]
        public int ID_DETALLE_ESTUDIOS { get; set; }

        public int? ESTUDIOSID { get; set; }

        public int? CATALOGO_ESTUDIOS_ID { get; set; }

        public int? CANTIDAD { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public decimal? SUBTOTAL { get; set; }

        public virtual CATALOGO_ESTUDIOS CATALOGO_ESTUDIOS { get; set; }

        public virtual ESTUDIO ESTUDIO { get; set; }
    }
}
