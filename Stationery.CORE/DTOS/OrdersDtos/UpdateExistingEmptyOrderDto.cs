using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.OrdersDtos
{
    public class UpdateExistingEmptyOrderDto
    {
        
        public double? SubTotal { get; set; }
        public double? GrandTotal { get; set; }
        public double? Paid { get; set; }
        public double? Remained { get; set; }
        public double? AdditionalService { get; set; }
        public double? DelivaryService { get; set; }
        public double? Tax { get; set; }
        public double? MinimumCharge { get; set; }
        public double? Discount { get; set; }
        [DefaultValue(true)]
        public bool? Finished { get; set; } = true;
    }
}
