namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLASIFICACION_ESTUDIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLASIFICACION_ESTUDIOS()
        {
            CATALOGO_ESTUDIOS = new HashSet<CATALOGO_ESTUDIOS>();
        }

        [Key]
        public int CLASIFICACIONID { get; set; }

        [StringLength(200)]
        public string NOMBRE { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATALOGO_ESTUDIOS> CATALOGO_ESTUDIOS { get; set; }
    }
}
