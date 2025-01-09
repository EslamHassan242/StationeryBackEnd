using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        [MaxLength(200)]
       
        public string ProductName { get; set; }
        [MaxLength(100)]
        public string ProductCode { get; set; }

        public ICollection<OrdersDetails> OrdersDetails { get; set; }
        public ICollection<OrdersBuyDetails> OrdersBuyDetails { get; set; }
        public ICollection<ProductUnits> ProductUnits { get; set; }

        [ForeignKey("CategoryID")]
        public Categories Category { get; set; }

    }
}
