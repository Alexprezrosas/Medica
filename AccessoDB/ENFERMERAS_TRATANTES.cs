namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ENFERMERAS_TRATANTES
    {
        [Key]
        public int ID_ENFERMERA_TRATANTE { get; set; }

        public int ENFERMERAID { get; set; }

        public int PACIENTEID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual ENFERMERA ENFERMERA { get; set; }

        public virtual PACIENTE PACIENTE { get; set; }
    }
}
