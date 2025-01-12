using Microsoft.EntityFrameworkCore;
using Stationery.CORE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.DTOS.OrderDetailsDtos
{
    public class OrderDetailsResponseDto :BasicOrderDetailsDto
    {
       
        public decimal ID { get; set; }
       

    
    }
}
