namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPOSITOS")]
    public partial class DEPOSITO
    {
        [Key]
        public int ID_DEPOSITO { get; set; }

        public decimal? MONTO { get; set; }

        [StringLength(200)]
        public string CONCEPTO { get; set; }

        public int USUARIOID { get; set; }

        [StringLength(200)]
        public string COMENTARIO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? CUENTAID { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
