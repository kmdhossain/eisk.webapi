using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eisk.Domains.Entities
{
    using BaseEntities;

    [Table("Orders")]
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public double OrderCalculatedTotal { get; set; }
        
        public virtual IList<OrderItem> OrderItems { get; set; }

    }
}