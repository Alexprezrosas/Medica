namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESTUDIOS")]
    public partial class ESTUDIO
    {
        [Key]
        public int ID_ESTUDIO { get; set; }

        public int MEDICOID { get; set; }

        public int CATALOGO_ESTUDIOS_ID { get; set; }

        public decimal? TOTAL { get; set; }

        public decimal? CARGO_EXTRA { get; set; }

        public int CUENTAID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? USUARIOID { get; set; }

        public virtual CATALOGO_ESTUDIOS CATALOGO_ESTUDIOS { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
