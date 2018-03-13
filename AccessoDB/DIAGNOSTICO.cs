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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIAGNOSTICO()
        {
            CONSULTAS = new HashSet<CONSULTA>();
        }

        [Key]
        public int ID_DIAGNOSTICO { get; set; }

        public int MEDICO_TRATANTEID { get; set; }

        [Column("DIAGNOSTICO")]
        [StringLength(200)]
        public string DIAGNOSTICO1 { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSULTA> CONSULTAS { get; set; }

        public virtual MEDICOS_TRATANTES MEDICOS_TRATANTES { get; set; }
    }
}
