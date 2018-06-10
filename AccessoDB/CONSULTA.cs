namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONSULTAS")]
    public partial class CONSULTA
    {
        [Key]
        public int ID_CONSULTA { get; set; }

        public int MEDICOID { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? PACIENTEID { get; set; }

        [StringLength(200)]
        public string NOM_PACIENTE { get; set; }

        [StringLength(200)]
        public string DIAGNOSTICO { get; set; }

        [StringLength(500)]
        public string DESCRIPCION { get; set; }

        [StringLength(1000)]
        public string MEDICAMENTOS { get; set; }

        public int? USUARIOID { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual PACIENTE PACIENTE { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
