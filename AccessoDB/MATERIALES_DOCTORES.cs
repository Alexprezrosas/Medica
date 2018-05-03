namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MATERIALES_DOCTORES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATERIALES_DOCTORES()
        {
            DETALLE_MATER_DOCTORES = new HashSet<DETALLE_MATER_DOCTORES>();
        }

        [Key]
        public int ID_MATERIAL { get; set; }

        public decimal? TOTAL { get; set; }

        public int USUARIOID { get; set; }

        public int DOCTORID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_MATER_DOCTORES> DETALLE_MATER_DOCTORES { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
