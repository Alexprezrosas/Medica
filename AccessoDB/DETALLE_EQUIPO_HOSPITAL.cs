namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_EQUIPO_HOSPITAL
    {
        [Key]
        public int ID_DETALLE_EQUIPO_HOSPITAL { get; set; }

        public int? EQUIPO_HOSPITALID { get; set; }

        public int? CATALOGO_EQUIPO_HOSPITALID { get; set; }

        public int? CANTIDAD { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_EQUIPO_HOSPITAL CATALOGO_EQUIPO_HOSPITAL { get; set; }

        public virtual EQUIPO_HOSPITAL EQUIPO_HOSPITAL { get; set; }
    }
}
