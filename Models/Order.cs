using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bar.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Display(Name = "Your Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Menu Item ID")]
        public int MenuID { get; set; }

        [Display(Name = "Quantity")]
        public int QuantityOfBeers { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [ForeignKey("MenuID")]
        public BarMenu BarMenu { get; set; }
    }
}
