namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEDICOS")]
    public partial class Medico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medico()
        {
            CIRUGIAS = new HashSet<CIRUGIA>();
            CONSULTAS = new HashSet<CONSULTA>();
            CUARTOS = new HashSet<CUARTO>();
            EQUIPO_HOSPITAL = new HashSet<EQUIPO_HOSPITAL>();
            ESPECIALIDADES = new HashSet<ESPECIALIDADE>();
            ESTUDIOS = new HashSet<ESTUDIO>();
            HONORARIOS_MEDICOS = new HashSet<HONORARIOS_MEDICOS>();
            MEDICOS_TRATANTES = new HashSet<MEDICOS_TRATANTES>();
        }

        [Key]
        public int ID_MEDICO { get; set; }

        public int PERSONAID { get; set; }

        [StringLength(20)]
        public string T_CONSULTORIO { get; set; }

        [Required]
        [StringLength(20)]
        public string T_PARTICULAR { get; set; }

        [Required]
        [StringLength(150)]
        public string CORREO { get; set; }

        [Required]
        [StringLength(50)]
        public string C_PROFESIONAL { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIRUGIA> CIRUGIAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSULTA> CONSULTAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUARTO> CUARTOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPO_HOSPITAL> EQUIPO_HOSPITAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESPECIALIDADE> ESPECIALIDADES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTUDIO> ESTUDIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HONORARIOS_MEDICOS> HONORARIOS_MEDICOS { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEDICOS_TRATANTES> MEDICOS_TRATANTES { get; set; }
    }
}
