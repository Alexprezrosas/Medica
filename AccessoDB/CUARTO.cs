namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUARTOS")]
    public partial class CUARTO
    {
        [Key]
        public int ID_CUARTO { get; set; }

        public int MEDICOID { get; set; }

        public int CUENTAID { get; set; }

        public int CATALOGO_CUARTOID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public decimal? TOTAL { get; set; }

        public virtual CATALOGO_CUARTOS CATALOGO_CUARTOS { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
