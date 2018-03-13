namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_EQUIPO_HOSPITAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATALOGO_EQUIPO_HOSPITAL()
        {
            EQUIPO_HOSPITAL = new HashSet<EQUIPO_HOSPITAL>();
        }

        [Key]
        public int ID_EQUIPO_HOSPITAL { get; set; }

        [Required]
        [StringLength(100)]
        public string NOM_EQUIPO_HOSPITAL { get; set; }

        [Required]
        [StringLength(150)]
        public string DESCRIPCION { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPO_HOSPITAL> EQUIPO_HOSPITAL { get; set; }
    }
}
