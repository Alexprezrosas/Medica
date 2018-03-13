namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_CIRUGIAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATALOGO_CIRUGIAS()
        {
            CIRUGIAS = new HashSet<CIRUGIA>();
        }

        [Key]
        public int ID_CATALOGO_CIRUGIA { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_CIRUGIA { get; set; }

        [Required]
        [StringLength(150)]
        public string DESCRIPCION { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIRUGIA> CIRUGIAS { get; set; }
    }
}
