using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleTax.Models;
using SaleTax.Repository.Products;
using SaleTax.Repository.utils;

namespace SaleTax.Repository.Shopping
{
    public class ShoppingCart
    {
        private List<CartItem> productList { get; set; }

        public ShoppingCart()
        {
            productList = new List<CartItem>();
        }

        public void AddItemToCart(CartItem cartItem)
        {
            productList.Add(cartItem);
        }

        public List<CartItem> GetItemsFromCart()
        {
            return productList;
        }

        public int GetCartSize()
        {
            return productList.Count;
        }
        public double GetTotalCost()
        {
            double totalCost = 0;
            foreach(CartItem product in productList)
            {
                totalCost += product.TaxedCost;
            }
            return totalCost;
        }
        public double GetSalesTax()
        {
            double totalCost = 0;
            double kk = 0;
            foreach (CartItem product in productList)
            {
                totalCost += product.TaxedCost;
                kk += product.SubTotal;
            }
            return TaxUtil.Truncate(TaxUtil.RoundOff(totalCost - kk));
        }
    }
}
