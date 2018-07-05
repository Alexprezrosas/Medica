namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUMINISTROS_MEDICAMENTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUMINISTROS_MEDICAMENTOS()
        {
            DETALLE_SUMINISTROS_MEDICAMENTOS = new HashSet<DETALLE_SUMINISTROS_MEDICAMENTOS>();
        }

        [Key]
        public int ID_SUMINISTRO_MEDICAMENTO { get; set; }

        public int CUENTAID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public decimal? TOTAL { get; set; }

        public int? USUARIOID { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_SUMINISTROS_MEDICAMENTOS> DETALLE_SUMINISTROS_MEDICAMENTOS { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
