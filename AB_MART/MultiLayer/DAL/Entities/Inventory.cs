using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public double  Purchase_Price { get; set; }

        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}
