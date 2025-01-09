using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.Models
{
    public class ProductUnits
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UnitId { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }
        public Units Units { get; set; }
    }
}
