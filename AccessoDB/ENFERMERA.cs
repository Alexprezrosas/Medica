namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ENFERMERAS")]
    public partial class ENFERMERA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENFERMERA()
        {
            ESPECIALIDADES_ENFERMERAS = new HashSet<ESPECIALIDADES_ENFERMERAS>();
            ENFERMERAS_TRATANTES = new HashSet<ENFERMERAS_TRATANTES>();
        }

        [Key]
        public int ID_ENFERMERA { get; set; }

        public int PERSONAID { get; set; }

        [StringLength(50)]
        public string C_PROFESIONAL { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESPECIALIDADES_ENFERMERAS> ESPECIALIDADES_ENFERMERAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENFERMERAS_TRATANTES> ENFERMERAS_TRATANTES { get; set; }
    }
}
