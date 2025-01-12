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
    public class ProductUnits
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int UnitId { get; set; }
        public int ProductId { get; set; }
        [Precision(18, 4)]
        public decimal Quentity { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [ForeignKey("UnitId")]
        public Units Units { get; set; }
    }
}
