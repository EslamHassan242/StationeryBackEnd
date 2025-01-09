using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.Models
{
    [Table("OrdersBuy")]
    public class OrdersBuy
    {
        [Precision(18,0)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }
        
        public DateTime OrderDate { get; set; }
        [MaxLength(50)]
        public string OrderNumber { get; set; }
        public double? SubTotal { get; set; }
        public double? GrandTotal { get; set; }
        public int SupplierId { get; set; }

        public bool? Finished { get; set; }
        public ICollection<OrdersBuyDetails> OrdersBuyDetails { get; set; }


        [ForeignKey("SupplierId")]
        public Suppliers Supplier { get; set; }
    }
}
