namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EQUIPO_HOSPITAL
    {
        [Key]
        public int ID_EQUIPO_HOSPITAL { get; set; }

        public int MEDICOID { get; set; }

        public int CATALOGO_EQUIPO_HOSPITALID { get; set; }

        public decimal? TOTAL { get; set; }

        public int CUENTAID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_EQUIPO_HOSPITAL CATALOGO_EQUIPO_HOSPITAL { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
