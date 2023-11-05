namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Producto_Pedido
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PEDIDO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PRODUCTO { get; set; }

        public int? CANTIDAD { get; set; }

        public decimal? SUBTOTAL { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
