using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.ProductsDtos
{
    public class InsertProductsDto
    {
       
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
}
