namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_ESTUDIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATALOGO_ESTUDIOS()
        {
            DETALLE_ESTUDIOS = new HashSet<DETALLE_ESTUDIOS>();
        }

        [Key]
        public int CATALOGO_ESTUDIO_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE { get; set; }

        [StringLength(255)]
        public string DESCRIPCION { get; set; }

        public int CLASIFICACIONID { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        public virtual CLASIFICACION_ESTUDIOS CLASIFICACION_ESTUDIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_ESTUDIOS> DETALLE_ESTUDIOS { get; set; }
    }
}
