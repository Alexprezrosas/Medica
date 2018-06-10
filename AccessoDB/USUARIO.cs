namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIOS")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            CIRUGIAS = new HashSet<CIRUGIA>();
            COMPRAS = new HashSet<COMPRA>();
            CONSULTAS = new HashSet<CONSULTA>();
            DEPOSITOS = new HashSet<DEPOSITO>();
            DEVOLUCIONES = new HashSet<DEVOLUCIONE>();
            EQUIPO_HOSPITAL = new HashSet<EQUIPO_HOSPITAL>();
            ESTUDIOS = new HashSet<ESTUDIO>();
            HONORARIOS_MEDICOS = new HashSet<HONORARIOS_MEDICOS>();
            MATERIALES_DOCTORES = new HashSet<MATERIALES_DOCTORES>();
            MATERIALES_ENFERMERAS = new HashSet<MATERIALES_ENFERMERAS>();
            VENTAS_GENERALES = new HashSet<VENTAS_GENERALES>();
        }

        [Key]
        public int ID_USUARIO { get; set; }

        public int EMPLEADOID { get; set; }

        [Required]
        [StringLength(30)]
        public string CONTRASENA { get; set; }

        public int PERMISOSID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CIRUGIA> CIRUGIAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPRA> COMPRAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSULTA> CONSULTAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPOSITO> DEPOSITOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEVOLUCIONE> DEVOLUCIONES { get; set; }

        public virtual EMPLEADO EMPLEADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPO_HOSPITAL> EQUIPO_HOSPITAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTUDIO> ESTUDIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HONORARIOS_MEDICOS> HONORARIOS_MEDICOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIALES_DOCTORES> MATERIALES_DOCTORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIALES_ENFERMERAS> MATERIALES_ENFERMERAS { get; set; }

        public virtual PERMISO PERMISO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTAS_GENERALES> VENTAS_GENERALES { get; set; }
    }
}
