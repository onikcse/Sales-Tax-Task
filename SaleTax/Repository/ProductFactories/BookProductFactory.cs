using SaleTax.Repository.Products;

namespace SaleTax.Repository.ProductFactories
{
    public class BookProductFactory : ProductFactory
    {
        public override Product CeateProduct(string name, double price, bool imported, int quantity)
        {
            return new BookProduct(name, price, imported, quantity);
        }
    }
}
