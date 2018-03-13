namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESPECIALIDADES")]
    public partial class ESPECIALIDADE
    {
        [Key]
        public int ID_ESPECIALIDAD { get; set; }

        public int MEDICOID { get; set; }

        public int CATALOGO_ESPECIALIDAD_ID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public virtual CATALOGO_ESPECIALIDADES CATALOGO_ESPECIALIDADES { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
