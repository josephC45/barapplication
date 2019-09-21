using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bar.Models
{
    public class BarMenu
    {
        public int ID { get; set; }

        [Display(Name = "Drink Name")]
        public string DrinkName { get; set; }

        [Display(Name = "Description")]
        public string DrinkDescription { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}
