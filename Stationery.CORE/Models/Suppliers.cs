using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.CORE.Models
{
    [Table("Suppliers")]
    public class Suppliers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Address { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        
        public string? Notes { get; set; }
        public ICollection<OrdersBuy> OrdersBuy { get; set; }
    }
}
