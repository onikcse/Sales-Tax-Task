using SaleTax.Repository.ProductFactories;
using SaleTax.Repository.TaxCalculations;

namespace SaleTax.Repository.Products
{
    public abstract class Product
    {
        public string Name { get; set; }

        private double _price;
        public double Price
        {
            set { _price = value; }
            get { return _price * Quantity; }
        }

        public bool Imported { get; set; }

        public int Quantity { get; set; }

        public double TaxedCost {
            get {
                var calculator = new LocalTaxCalculator();
                return calculator.CalculateTax(_price, GetTaxValue(ImportedToString(Imported)), Imported);
            }
            set
            {
                
            }
        }

        public Product()
        {
            this.Name = string.Empty;
            this.Price = 0.0;
            this.Imported = false;
            this.Quantity = 0;
            this.TaxedCost = 0.0;
        }

        public Product(string name, double price, bool imported, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Imported = imported;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            return (Quantity + " " + ImportedToString(Imported) + " " + Name + " : " + TaxedCost);
        }

        public string ImportedToString(bool imported)
        {
            if (!imported)
                return "Local";
            else
                return "Imported";
        }

        public abstract ProductFactory GetFactory();

        public abstract double GetTaxValue(string country);
    }
}
