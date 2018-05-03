namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ESPECIALIDADES_ENFERMERAS
    {
        [Key]
        public int ID_ESPECIALIDAD_ENFERMERA { get; set; }

        public int ENFERMERAID { get; set; }

        public int CATALOGO_ESPECIALIDADESID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_ESPECIALIDADES CATALOGO_ESPECIALIDADES { get; set; }

        public virtual ENFERMERA ENFERMERA { get; set; }
    }
}
