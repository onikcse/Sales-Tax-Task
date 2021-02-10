
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleTax.Repository.Products;

namespace SaleTax.Repository.ProductFactories
{
    public class FoodProductFactory : ProductFactory
    {
        public override Product CeateProduct(string name, double price, bool imported, int quantity)
        {
            return new FoodProduct(name, price, imported, quantity);
        }
    }
}
