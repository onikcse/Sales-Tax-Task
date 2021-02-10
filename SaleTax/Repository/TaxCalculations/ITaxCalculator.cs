using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleTax.Repository.TaxCalculations
{
    public interface ITaxCalculator
    {
        double CalculateTax(double price, double tax, bool imported);
    }
}
