using Stationery.CORE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.SuppliersDtos
{
    public class SuppliersResponseDto
    {
        
        public int ID { get; set; }
        public string Name { get; set; } = "";     
        public string? Address { get; set; }       
        public string? Phone { get; set; }
        public string? Notes { get; set; }      
    }
}
