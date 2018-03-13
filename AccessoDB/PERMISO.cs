namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERMISOS")]
    public partial class PERMISO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERMISO()
        {
            ROLES = new HashSet<ROLE>();
        }

        [Key]
        public int ID_PERMISO { get; set; }

        [Required]
        [StringLength(200)]
        public string NOM_PERMISO { get; set; }

        [StringLength(200)]
        public string DESCIPCION { get; set; }

        public int MODULOID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual MODULO MODULO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLE> ROLES { get; set; }
    }
}
