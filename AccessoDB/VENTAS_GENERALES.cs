namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VENTAS_GENERALES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTAS_GENERALES()
        {
            DETALLE_VENTAS = new HashSet<DETALLE_VENTAS>();
        }

        [Key]
        public int ID_VENTA_GENERAL { get; set; }

        public decimal? TOTAL { get; set; }

        public decimal? IMPORTE { get; set; }

        public decimal? IVA { get; set; }

        public decimal? DESCUENTO { get; set; }

        public int USUARIOID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [StringLength(100)]
        public string CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_VENTAS> DETALLE_VENTAS { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
