namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMPRAS")]
    public partial class COMPRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMPRA()
        {
            DETALLE_COMPRAS = new HashSet<DETALLE_COMPRAS>();
        }

        [Key]
        public int ID_COMPRA { get; set; }

        public int NUM_FACTURA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FECHA_COMPRA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FECHA_VENCIMIENTO { get; set; }

        public int PROVEEDORID { get; set; }

        [StringLength(200)]
        public string ALMACEN { get; set; }

        [StringLength(250)]
        public string COMENTARIO { get; set; }

        public decimal? IMPORTE { get; set; }

        public decimal? IVA { get; set; }

        public decimal? TOTAL { get; set; }

        public int USUARIOID { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual PROVEEDORE PROVEEDORE { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_COMPRAS> DETALLE_COMPRAS { get; set; }
    }
}
