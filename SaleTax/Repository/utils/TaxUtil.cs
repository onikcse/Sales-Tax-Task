using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleTax.Repository.utils
{
    public class TaxUtil
    {
        private const double ROUND_OFF = 0.05;

        public static double RoundOff(double value)
        {
            return (int)(value / ROUND_OFF + 0.5) * 0.05;
        }

        public static double Truncate(double value)
        {
            String result = value.ToString("N2"); ;
            return Double.Parse(result);
        }
    }
}
