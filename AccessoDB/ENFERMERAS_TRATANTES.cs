namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ENFERMERAS_TRATANTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENFERMERAS_TRATANTES()
        {
            SUMINISTROS_MEDICAMENTOS = new HashSet<SUMINISTROS_MEDICAMENTOS>();
        }

        [Key]
        public int ID_ENFERMERA_TRATANTE { get; set; }

        public int ENFERMERAID { get; set; }

        public int PACIENTEID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual ENFERMERA ENFERMERA { get; set; }

        public virtual PACIENTE PACIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUMINISTROS_MEDICAMENTOS> SUMINISTROS_MEDICAMENTOS { get; set; }
    }
}
