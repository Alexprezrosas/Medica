namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_MATERIALES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATALOGO_MATERIALES()
        {
            MATERIALES_DOCTORES = new HashSet<MATERIALES_DOCTORES>();
            MATERIALES_ENFERMERAS = new HashSet<MATERIALES_ENFERMERAS>();
        }

        [Key]
        public int ID_CATALOGO_MATERIAL { get; set; }

        [Required]
        [StringLength(200)]
        public string NOMBRE { get; set; }

        public int CANTIDAD { get; set; }

        [StringLength(200)]
        public string COMENTARIO { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? COD_BARRAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIALES_DOCTORES> MATERIALES_DOCTORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIALES_ENFERMERAS> MATERIALES_ENFERMERAS { get; set; }
    }
}
