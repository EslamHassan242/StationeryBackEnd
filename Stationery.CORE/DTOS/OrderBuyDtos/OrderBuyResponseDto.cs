using Microsoft.EntityFrameworkCore;
using Stationery.CORE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.OrderBuyDtos
{
    public class OrderBuyResponseDto
    {
        public decimal ID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public double? SubTotal { get; set; }
        public double? GrandTotal { get; set; }
        public int SupplierId { get; set; }
        public bool? Finished { get; set; }      


       
    }
}
