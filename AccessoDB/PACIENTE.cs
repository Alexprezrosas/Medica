namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PACIENTES")]
    public partial class PACIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PACIENTE()
        {
            CONSULTAS = new HashSet<CONSULTA>();
            CUENTAS = new HashSet<CUENTA>();
            ENFERMERAS_TRATANTES = new HashSet<ENFERMERAS_TRATANTES>();
            FAM_RESPONSABLES = new HashSet<FAM_RESPONSABLES>();
            HONORARIOS_MEDICOS = new HashSet<HONORARIOS_MEDICOS>();
        }

        [Key]
        public int ID_PACIENTE { get; set; }

        public int PERSONAID { get; set; }

        [StringLength(50)]
        public string TIPO_PACIENTE { get; set; }

        public int CONSULTAID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSULTA> CONSULTAS { get; set; }

        public virtual CONSULTA CONSULTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUENTA> CUENTAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENFERMERAS_TRATANTES> ENFERMERAS_TRATANTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAM_RESPONSABLES> FAM_RESPONSABLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HONORARIOS_MEDICOS> HONORARIOS_MEDICOS { get; set; }

        public virtual PERSONA PERSONA { get; set; }
    }
}
