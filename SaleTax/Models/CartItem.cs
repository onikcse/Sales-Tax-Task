using System;
namespace SaleTax.Models
{
    public class CartItem
    {
        public CartItem()
        {
        }

        public string Name { get; set; }
        public string IsImported { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double SubTotal { get; set; }
        public double TaxedCost { get; set; }
    }
}
