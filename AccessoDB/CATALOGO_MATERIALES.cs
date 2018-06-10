namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATALOGO_MATERIALES
    {
        [Key]
        public int ID_CATALOGO_MATERIAL { get; set; }

        [Required]
        [StringLength(200)]
        public string NOMBRE { get; set; }

        public int CANTIDAD { get; set; }

        [StringLength(200)]
        public string COMENTARIO { get; set; }

        public decimal? COSTO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public DateTime? FECHA_MOD { get; set; }

        public int? COD_BARRAS { get; set; }

        [StringLength(100)]
        public string U_MEDIDA { get; set; }

        public int? CFDI { get; set; }
    }
}
