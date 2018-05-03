namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_SUMINISTROS_MEDICAMENTOS
    {
        [Key]
        public int ID_DETALLE_SUMINISTRO { get; set; }

        public int SUMINISTRO_MEDICAMENTOID { get; set; }

        public int MEDICAMENTOID { get; set; }

        public decimal? PRECIO { get; set; }

        public int CANTIDAD { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public decimal? IVA { get; set; }

        public virtual CATALOGO_MEDICAMENTOS CATALOGO_MEDICAMENTOS { get; set; }

        public virtual SUMINISTROS_MEDICAMENTOS SUMINISTROS_MEDICAMENTOS { get; set; }
    }
}
