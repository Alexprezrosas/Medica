namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EQUIPO_HOSPITAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EQUIPO_HOSPITAL()
        {
            DETALLE_EQUIPO_HOSPITAL = new HashSet<DETALLE_EQUIPO_HOSPITAL>();
        }

        [Key]
        public int ID_EQUIPO_HOSPITAL { get; set; }

        public int MEDICOID { get; set; }

        public decimal? TOTAL { get; set; }

        public int CUENTAID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? USUARIOID { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_EQUIPO_HOSPITAL> DETALLE_EQUIPO_HOSPITAL { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
