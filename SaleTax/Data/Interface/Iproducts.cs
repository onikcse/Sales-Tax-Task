using System;
using System.Collections.Generic;
using SaleTax.Repository.Products;

namespace SaleTax.Data.Interface
{
    public interface IProducts
    {
        IEnumerable<Product> Products { get; set; }
    }

}
