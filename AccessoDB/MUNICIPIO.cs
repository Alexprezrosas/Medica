namespace AccessoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MUNICIPIOS")]
    public partial class MUNICIPIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MUNICIPIO()
        {
            LOCALIDADES = new HashSet<LOCALIDADE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int estado_id { get; set; }

        [Required]
        [StringLength(3)]
        public string clave { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public byte activo { get; set; }

        public virtual ESTADO ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCALIDADE> LOCALIDADES { get; set; }
    }
}
