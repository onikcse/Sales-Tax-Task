using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleTax.Repository.Products;

namespace SaleTax.Repository.ProductFactories
{
    public abstract class ProductFactory
    {
        public abstract Product CeateProduct(String name, double price, bool imported, int quantity);
    }
}
