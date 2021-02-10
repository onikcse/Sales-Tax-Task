
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleTax.Repository.Products;

namespace SaleTax.Repository.ProductFactories
{
    public class MedicalProductFactory : ProductFactory
    {
        public override Product CeateProduct(string name, double price, bool imported, int quantity)
        {
            return new MedicalProduct(name, price, imported, quantity);
        }
    }
}
