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
            USUARIOS = new HashSet<USUARIO>();
        }

        [Key]
        public int ID_PERMISO { get; set; }

        [Required]
        [StringLength(200)]
        public string NOM_PERMISO { get; set; }

        [StringLength(200)]
        public string DESCIPCION { get; set; }

        [Required]
        [StringLength(30)]
        public string MODULOS { get; set; }

        [Required]
        [StringLength(50)]
        public string ROL { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIOS { get; set; }
    }
}
