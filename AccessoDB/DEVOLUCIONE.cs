namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEVOLUCIONES")]
    public partial class DEVOLUCIONE
    {
        [Key]
        public int ID_DEVOLUCION { get; set; }

        public int MEDICMANETOID { get; set; }

        public int CANTIDAD { get; set; }

        public int USUARIOID { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? CUENTAID { get; set; }

        public virtual CATALOGO_MEDICAMENTOS CATALOGO_MEDICAMENTOS { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
