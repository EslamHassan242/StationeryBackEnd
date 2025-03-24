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
    [Table("OrdersBuyDetails")]
    public class OrdersBuyDetails
    {
        [Key]
        [Precision(18,0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }
        [Precision(18, 0)]
        
        public int ProductId { get; set; }
        [Precision(18, 4)]
        public decimal Quentity { get; set; }    
        
        public Products Product { get; set; }
        public OrdersBuy OrderBuy { get; set; }
        public decimal OrderBuyId { get; set; }

    }
}
