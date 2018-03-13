namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPOSITOS")]
    public partial class DEPOSITO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPOSITO()
        {
            CUENTAS = new HashSet<CUENTA>();
        }

        [Key]
        public int ID_DEPOSITO { get; set; }

        public decimal? MONTO { get; set; }

        [StringLength(200)]
        public string CONCEPTO { get; set; }

        public int USUARIOID { get; set; }

        [StringLength(200)]
        public string COMENTARIO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUENTA> CUENTAS { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
