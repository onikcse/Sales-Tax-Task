using System;
using System.Collections.Generic;

namespace SaleTax.Repository.Shopping
{
    public interface IShoppingCart
    {
        IEnumerable<ShoppingCart> ShoppingCart { get; set; }
    }
}
