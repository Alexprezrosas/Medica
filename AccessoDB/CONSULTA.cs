namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONSULTAS")]
    public partial class CONSULTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONSULTA()
        {
            PACIENTES = new HashSet<PACIENTE>();
        }

        [Key]
        public int ID_CONSULTA { get; set; }

        public int MEDICOID { get; set; }

        public int PACIENTEID { get; set; }

        public int DIAGNOSTICOID { get; set; }

        [StringLength(200)]
        public string DESCRIPCION { get; set; }

        public int MEDICAMENTOID { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_MEDICAMENTOS CATALOGO_MEDICAMENTOS { get; set; }

        public virtual DIAGNOSTICO DIAGNOSTICO { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual PACIENTE PACIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PACIENTE> PACIENTES { get; set; }
    }
}
