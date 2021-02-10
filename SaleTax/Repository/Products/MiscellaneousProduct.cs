using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleTax.Repository.ProductFactories;
using SaleTax.Repository.Products;
using SaleTax.Repository.TaxCalculations;

namespace SaleTax.Repository.Products
{
    public class MiscellaneousProduct : Product
    {
        public MiscellaneousProduct()
            : base()
        {
        }
        public MiscellaneousProduct(String name, double price, bool imported, int quantity)
            : base(name, price, imported, quantity)
        {
        }
        public override ProductFactory GetFactory()
        {
            return new MiscellaneousProductFactory();
        }

        public override double GetTaxValue(string country)
        {
            return LocalTaxValues.MISC_TAX;
        }
    }
}
