namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_MATER_DOCTORES
    {
        [Key]
        public int ID_DETALLE_MATER_DOCTOR { get; set; }

        public int MATERIALES_DOCTORESID { get; set; }

        public int MATERIALID { get; set; }

        public int CANTIDAD { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual MATERIALES_DOCTORES MATERIALES_DOCTORES { get; set; }
    }
}
