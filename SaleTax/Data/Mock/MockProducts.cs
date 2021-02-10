using System;
using System.Collections.Generic;
using SaleTax.Data.DatabaseHandler;
using SaleTax.Data.Interface;
using SaleTax.Repository.Products;
using SaleTax.Repository.Shopping;

namespace SaleTax.Data.Mock
{
    public class MockProducts : IProducts
    {
        public MockProducts()
        {
        }

        public IEnumerable<Product> Products
        {
            get
            {
                DataHandler data = new DataHandler();
                return data.GetAllProduct();
            }
            set
            {

            }
    }

    }
    

}
