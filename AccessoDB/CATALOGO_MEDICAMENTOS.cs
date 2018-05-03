namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_MEDICAMENTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATALOGO_MEDICAMENTOS()
        {
            CONSULTAS = new HashSet<CONSULTA>();
            DETALLE_COMPRAS = new HashSet<DETALLE_COMPRAS>();
            DETALLE_VENTAS = new HashSet<DETALLE_VENTAS>();
            DETALLE_SUMINISTROS_MEDICAMENTOS = new HashSet<DETALLE_SUMINISTROS_MEDICAMENTOS>();
            DEVOLUCIONES = new HashSet<DEVOLUCIONE>();
        }

        [Key]
        public int ID_MEDICAMENTO { get; set; }

        [Required]
        [StringLength(250)]
        public string NOMBRE_MEDI { get; set; }

        public int CANTIDAD { get; set; }

        [StringLength(250)]
        public string COMENTARIO { get; set; }

        public decimal? P_VENTA { get; set; }

        public decimal? P_COMPRA { get; set; }

        public decimal? P_MEDICOS { get; set; }

        public decimal? DESCUENTO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CADUCIDAD { get; set; }

        public int? MEDICAMENTO_ORIGENID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? COD_BARRAS { get; set; }

        [StringLength(100)]
        public string U_MEDIDA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSULTA> CONSULTAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_COMPRAS> DETALLE_COMPRAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_VENTAS> DETALLE_VENTAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_SUMINISTROS_MEDICAMENTOS> DETALLE_SUMINISTROS_MEDICAMENTOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEVOLUCIONE> DEVOLUCIONES { get; set; }
    }
}
