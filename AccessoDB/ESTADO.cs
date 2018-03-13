namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESTADOS")]
    public partial class ESTADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADO()
        {
            MUNICIPIOS = new HashSet<MUNICIPIO>();
            PERSONAS = new HashSet<PERSONA>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(2)]
        public string clave { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        [Required]
        [StringLength(16)]
        public string abrev { get; set; }

        public byte activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUNICIPIO> MUNICIPIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERSONA> PERSONAS { get; set; }
    }
}
