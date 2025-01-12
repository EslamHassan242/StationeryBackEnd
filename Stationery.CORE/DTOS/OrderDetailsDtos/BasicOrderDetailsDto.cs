using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.OrderDetailsDtos
{
    public class BasicOrderDetailsDto
    {
        public decimal OrderId { get; set; }
        public int UnitId { get; set; }
        public int ProductID { get; set; }
        public double? PriceSell { get; set; }
        public double? PriceBuy { get; set; }
        public double? TotalSell { get; set; }
        public double? TotalBuy { get; set; }
        public decimal Quentity { get; set; }
    }
}
