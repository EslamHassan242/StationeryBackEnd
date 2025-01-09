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
    [Table("OrdersDetails")]
    public class OrdersDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Precision(18,0)]
        public decimal ID { get; set; }
        [Precision(18, 0)]
        public decimal OrderId { get; set; }
        public int UnitId { get; set; }
        public int ProductID { get; set; }
        public double? PriceSell { get; set; }
        public double? PriceBuy { get; set; }
        public double? TotalSell { get; set; }
        public double? TotalBuy { get; set; }

        [Precision(18,4)]
        public decimal Quentity { get; set; }

        public Products Product { get; set; }
        public Units Units { get; set; }
        public Orders Order { get; set; }


    }
}
