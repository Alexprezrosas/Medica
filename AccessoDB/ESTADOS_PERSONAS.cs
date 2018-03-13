namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ESTADOS_PERSONAS
    {
        [Key]
        public int ID_ESTADO { get; set; }

        public int ID_PERSONA { get; set; }

        [StringLength(50)]
        public string ESTADO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual PERSONA PERSONA { get; set; }
    }
}
