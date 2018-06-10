namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CIRUGIAS")]
    public partial class CIRUGIA
    {
        [Key]
        public int ID_CIRUGIA { get; set; }

        public int MEDICOID { get; set; }

        [Required]
        [StringLength(150)]
        public string DESCRIPCION { get; set; }

        public int CATALOGO_CIRUGIAID { get; set; }

        public int CUENTAID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public decimal? TOTAL { get; set; }

        public int? USUARIOID { get; set; }

        public virtual CATALOGO_CIRUGIAS CATALOGO_CIRUGIAS { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
