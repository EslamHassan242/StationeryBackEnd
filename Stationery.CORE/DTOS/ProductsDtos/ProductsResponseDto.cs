using Stationery.CORE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.ProductsDtos
{
    public class ProductsResponseDto
    {        
        public int ID { get; set; }
        public int CategoryID { get; set; }   
        public string ProductName { get; set; }      
        public string ProductCode { get; set; }  
        
    }
}
