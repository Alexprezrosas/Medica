namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUMINISTROS_MEDICAMENTOS
    {
        [Key]
        public int ID_SUMINISTRO_MEDICAMENTO { get; set; }

        public int MEDICMANETOID { get; set; }

        public short CANTIDAD { get; set; }

        public decimal? PRECIO { get; set; }

        public int ENFERMERA_TRATANTEID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_MEDICAMENTOS CATALOGO_MEDICAMENTOS { get; set; }

        public virtual ENFERMERAS_TRATANTES ENFERMERAS_TRATANTES { get; set; }
    }
}
