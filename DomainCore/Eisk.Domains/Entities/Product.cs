using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eisk.Domains.Entities
{
    [Table("Product List")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCost { get; set; }
        public string ProductType { get; set; }
        public string ProductStatus { get; set; }

    }
}
