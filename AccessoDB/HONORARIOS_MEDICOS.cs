namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HONORARIOS_MEDICOS
    {
        [Key]
        public int ID_HONORARIO_MEDICO { get; set; }

        public int PACIENTEID { get; set; }

        public int MEDICOID { get; set; }

        public decimal? HONORIARIO { get; set; }

        public int USUARIOID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public decimal? TOTAL { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual PACIENTE PACIENTE { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
