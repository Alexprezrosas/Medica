namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIAGNOSTICOS")]
    public partial class DIAGNOSTICO
    {
        [Key]
        public int ID_DIAGNOSTICO { get; set; }

        public int MEDICO_TRATANTEID { get; set; }

        [Column("DIAGNOSTICO")]
        [StringLength(200)]
        public string DIAGNOSTICO1 { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual MEDICOS_TRATANTES MEDICOS_TRATANTES { get; set; }
    }
}
