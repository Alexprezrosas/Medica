namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MEDICOS_TRATANTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEDICOS_TRATANTES()
        {
            DIAGNOSTICOS = new HashSet<DIAGNOSTICO>();
        }

        [Key]
        public int ID_MEDICO_TRATANTE { get; set; }

        public int MEDICOID { get; set; }

        public int CUENTAID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIAGNOSTICO> DIAGNOSTICOS { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
