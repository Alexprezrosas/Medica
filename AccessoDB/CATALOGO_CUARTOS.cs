namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_CUARTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATALOGO_CUARTOS()
        {
            CUARTOS = new HashSet<CUARTO>();
        }

        [Key]
        public int ID_CATALOGO_CUARTO { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_CUARTO { get; set; }

        [Required]
        [StringLength(200)]
        public string DESCRIPCION { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [StringLength(100)]
        public string ESTADO { get; set; }

        public int? MAX_PACIENTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUARTO> CUARTOS { get; set; }
    }
}
