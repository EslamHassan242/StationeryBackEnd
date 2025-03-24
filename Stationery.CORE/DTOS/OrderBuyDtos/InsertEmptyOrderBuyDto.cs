using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.OrderBuyDtos
{
    public class InsertEmptyOrderBuyDto
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [DefaultValue(false)]
        public bool? Finished { get; set; } = false;       
        public string OrderNumber { get; set; } = string.Empty;   
    }
}
