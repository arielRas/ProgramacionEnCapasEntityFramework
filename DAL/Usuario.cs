namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DNI { get; set; }

        [StringLength(30)]
        public string APELLIDO { get; set; }

        [StringLength(60)]
        public string NOMBRE { get; set; }

        [StringLength(15)]
        public string TELEFONO { get; set; }

        [StringLength(100)]
        public string DIRECCION { get; set; }

        [StringLength(100)]
        public string CIUDAD { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(20)]
        public string PASSWORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
