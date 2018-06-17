namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERSONAS")]
    public partial class PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONA()
        {
            EMPLEADOS = new HashSet<EMPLEADO>();
            ENFERMERAS = new HashSet<ENFERMERA>();
            ESTADOS_PERSONAS = new HashSet<ESTADOS_PERSONAS>();
            FAM_RESPONSABLES = new HashSet<FAM_RESPONSABLES>();
            MEDICOS = new HashSet<Medico>();
            PACIENTES = new HashSet<PACIENTE>();
            PROVEEDORES = new HashSet<PROVEEDORE>();
        }

        [Key]
        public int ID_PERSONA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [StringLength(150)]
        public string CURP { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? F_NACIMIENTO { get; set; }

        [StringLength(50)]
        public string A_PATERNO { get; set; }

        [StringLength(50)]
        public string A_MATERNO { get; set; }

        [StringLength(50)]
        public string SEXO { get; set; }

        [StringLength(50)]
        public string T_CELULAR { get; set; }

        [StringLength(150)]
        public string CALLE { get; set; }

        public int? ESTADO { get; set; }

        [StringLength(100)]
        public string NOMMUNICIPIO { get; set; }

        [StringLength(100)]
        public string NOMLOCALIDAD { get; set; }

        [StringLength(50)]
        public string ESTADOPERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENFERMERA> ENFERMERAS { get; set; }

        public virtual ESTADO ESTADO1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTADOS_PERSONAS> ESTADOS_PERSONAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAM_RESPONSABLES> FAM_RESPONSABLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico> MEDICOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PACIENTE> PACIENTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVEEDORE> PROVEEDORES { get; set; }
    }
}
