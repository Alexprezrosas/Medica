namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOCALIDADES")]
    public partial class LOCALIDADE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int municipio_id { get; set; }

        [Required]
        [StringLength(4)]
        public string clave { get; set; }

        [Required]
        [StringLength(110)]
        public string nombre { get; set; }

        [Required]
        [StringLength(15)]
        public string latitud { get; set; }

        [Required]
        [StringLength(15)]
        public string longitud { get; set; }

        public decimal lat { get; set; }

        public decimal lng { get; set; }

        [Required]
        [StringLength(15)]
        public string altitud { get; set; }

        public byte activo { get; set; }

        public virtual MUNICIPIO MUNICIPIO { get; set; }
    }
}
