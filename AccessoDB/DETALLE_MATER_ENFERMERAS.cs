namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_MATER_ENFERMERAS
    {
        [Key]
        public int ID_DETALLE_MATER_ENFERMERA { get; set; }

        public int MATERIALES_ENFERMERASID { get; set; }

        public int MATERIALID { get; set; }

        public int CANTIDAD { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_MATERIALES CATALOGO_MATERIALES { get; set; }

        public virtual MATERIALES_ENFERMERAS MATERIALES_ENFERMERAS { get; set; }
    }
}
