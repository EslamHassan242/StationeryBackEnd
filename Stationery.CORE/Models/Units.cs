using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.Models
{
    [Table("Units")]
    public class Units
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(100)]
        public string? UnitName { get; set; }

        public ICollection<ProductUnits> ProductUnits { get; set; }
        public ICollection<OrdersDetails> OrdersDetails { get; set; }

    }
}
