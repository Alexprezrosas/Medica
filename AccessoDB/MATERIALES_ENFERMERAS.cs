namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MATERIALES_ENFERMERAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATERIALES_ENFERMERAS()
        {
            DETALLE_MATER_ENFERMERAS = new HashSet<DETALLE_MATER_ENFERMERAS>();
        }

        [Key]
        public int ID_MATERIAL { get; set; }

        public decimal? TOTAL { get; set; }

        public int USUARIOID { get; set; }

        public int ENFERMERAID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_MATER_ENFERMERAS> DETALLE_MATER_ENFERMERAS { get; set; }

        public virtual ENFERMERA ENFERMERA { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
