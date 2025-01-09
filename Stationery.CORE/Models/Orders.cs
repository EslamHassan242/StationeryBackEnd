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
    [Table ("Orders") ]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Precision(18,0)]
        public decimal ID { get; set; }
        public DateTime OrderDate { get; set; }
        public double? SubTotal { get; set; }
        public double? GrandTotal { get; set; }
        public double? Paid { get; set; }
        public double? Remained { get; set; }
        public double? AdditionalService { get; set; }
        public double? DelivaryService { get; set; }
        public double? Tax { get; set; }
        public double? MinimumCharge { get; set; }
        public double? Discount { get; set; }    
        public bool? Finished { get; set; }
        public ICollection<OrdersDetails> OrdersDetails { get; set; }

    }
}
