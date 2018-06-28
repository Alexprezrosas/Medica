namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_ESPECIALIDADES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATALOGO_ESPECIALIDADES()
        {
            ESPECIALIDADES_ENFERMERAS = new HashSet<ESPECIALIDADES_ENFERMERAS>();
            ESPECIALIDADES = new HashSet<ESPECIALIDADE>();
        }

        [Key]
        public int ID_CATALOGO_ESPECIALIDAD { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_ESPECIALIDAD { get; set; }

        [StringLength(200)]
        public string DESCRIPCION { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESPECIALIDADES_ENFERMERAS> ESPECIALIDADES_ENFERMERAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESPECIALIDADE> ESPECIALIDADES { get; set; }
    }
}
