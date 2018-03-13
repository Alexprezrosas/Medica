namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FAM_RESPONSABLES
    {
        [Key]
        public int ID_FAM_RESPOSABLE { get; set; }

        public int PERSONAID { get; set; }

        public int PACIENTEID { get; set; }

        [StringLength(150)]
        public string PARENTESCO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual PACIENTE PACIENTE { get; set; }

        public virtual PERSONA PERSONA { get; set; }
    }
}
