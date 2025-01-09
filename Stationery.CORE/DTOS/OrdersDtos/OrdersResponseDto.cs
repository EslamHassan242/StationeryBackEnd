using Stationery.CORE.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.OrdersDtos
{
    public class OrdersResponseDto
    {
        public decimal ID { get; set; }
        public DateTime OrderDate { get; set; }
        public double SubTotal { get; set; }
        public double GrandTotal { get; set; }
        public double Paid { get; set; }
        public double Remained { get; set; }
        public double AdditionalService { get; set; }
        public double DelivaryService { get; set; }
        public double Tax { get; set; }
        public double MinimumCharge { get; set; }
        public double Discount { get; set; }
        public bool Finished { get; set; }

    }
}
