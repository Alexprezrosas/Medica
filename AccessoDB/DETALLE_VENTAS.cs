namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_VENTAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DETALLE_VENTAS()
        {
            VENTAS_GENERALES = new HashSet<VENTAS_GENERALES>();
        }

        [Key]
        public int ID_DETALLE_VENTA { get; set; }

        public int MEDICAMENTOID { get; set; }

        public int CANTIDAD { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_MEDICAMENTOS CATALOGO_MEDICAMENTOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTAS_GENERALES> VENTAS_GENERALES { get; set; }
    }
}
