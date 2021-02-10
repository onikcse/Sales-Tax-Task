using System;
using System.Collections.Generic;
using SaleTax.Repository.Products;

namespace SaleTax.ViewModel
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
        }
        public IEnumerable<Product> Products { get; set; }
    }
}
