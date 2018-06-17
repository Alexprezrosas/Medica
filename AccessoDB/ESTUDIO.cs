namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESTUDIOS")]
    public partial class ESTUDIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTUDIO()
        {
            DETALLE_ESTUDIOS = new HashSet<DETALLE_ESTUDIOS>();
        }

        [Key]
        public int ID_ESTUDIO { get; set; }

        public decimal? TOTAL { get; set; }

        public decimal? CARGO_EXTRA { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? USUARIOID { get; set; }

        public int? MEDICOID { get; set; }

        public int? CUENTAID { get; set; }

        [StringLength(150)]
        public string MEDICO_SOLICITANTE { get; set; }

        [StringLength(150)]
        public string PACIENTE_SOLICITANTE { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_ESTUDIOS> DETALLE_ESTUDIOS { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
