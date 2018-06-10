namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROVEEDORES")]
    public partial class PROVEEDORE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVEEDORE()
        {
            COMPRAS = new HashSet<COMPRA>();
        }

        [Key]
        public int ID_PROVEEDOR { get; set; }

        public int PERSONAID { get; set; }

        [StringLength(200)]
        public string NOTA { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [StringLength(50)]
        public string RFC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPRA> COMPRAS { get; set; }

        public virtual PERSONA PERSONA { get; set; }
    }
}
