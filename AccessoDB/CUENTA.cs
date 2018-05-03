namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUENTAS")]
    public partial class CUENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUENTA()
        {
            CIRUGIAS = new HashSet<CIRUGIA>();
            CUARTOS = new HashSet<CUARTO>();
            DEVOLUCIONES = new HashSet<DEVOLUCIONE>();
            EQUIPO_HOSPITAL = new HashSet<EQUIPO_HOSPITAL>();
            ESTUDIOS = new HashSet<ESTUDIO>();
            MEDICOS_TRATANTES = new HashSet<MEDICOS_TRATANTES>();
            SUMINISTROS_MEDICAMENTOS = new HashSet<SUMINISTROS_MEDICAMENTOS>();
        }

        [Key]
        public int ID_CUENTA { get; set; }

        public int PACIENTEID { get; set; }

        public int DEPOSITOID { get; set; }

        public decimal? TOTAL { get; set; }

        [StringLength(50)]
        public string ESTADO { get; set; }

        public decimal? SALDO { get; set; }

        public decimal? IVA { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIRUGIA> CIRUGIAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUARTO> CUARTOS { get; set; }

        public virtual DEPOSITO DEPOSITO { get; set; }

        public virtual PACIENTE PACIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEVOLUCIONE> DEVOLUCIONES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPO_HOSPITAL> EQUIPO_HOSPITAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTUDIO> ESTUDIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEDICOS_TRATANTES> MEDICOS_TRATANTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUMINISTROS_MEDICAMENTOS> SUMINISTROS_MEDICAMENTOS { get; set; }
    }
}
