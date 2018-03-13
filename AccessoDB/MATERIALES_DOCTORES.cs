namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MATERIALES_DOCTORES
    {
        [Key]
        public int ID_MATERIAL { get; set; }

        public int CATALOGO_MATERIALID { get; set; }

        public decimal? TOTAL { get; set; }

        public int USUARIOID { get; set; }

        public int DOCTORID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_MATERIALES CATALOGO_MATERIALES { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
