using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SaleTax.Models;
using SaleTax.Repository.Products;

namespace SaleTax.Data.DatabaseHandler
{
    public class DataHandler
    {
        //todo configure the MySQL DB connection

        string serverIp = "localhost";
        string username = "root";
        string password = "root";
        string databaseName = "SalesTax";

        MySqlConnection connection;
        MySqlCommand mySqlCommand;

        private List<CartItem> productsAtCart = new List<CartItem>();
        public DataHandler()
        {

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
            this.connection = new MySqlConnection(dbConnectionString);
            connection.Open();
            Console.WriteLine(this.connection.Database);

            //InitializeDB();
        }

        public void InitializeDB()
        {

            string query = "Create database SalesTax if not exists;";
            MySqlCommand mySqlCommand = new MySqlCommand(query, this.connection);
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("DatabaseName Error : " + e);
            }

        }

        public int GetCartSize()
        {
            return GetCartProducts().Count;
        }
        public List<CartItem> GetCartProducts()
        {
            String query = "Select * from CartItems";
            mySqlCommand = new MySqlCommand(query, this.connection);
            var reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                CartItem cartItem = new CartItem();
                cartItem.Name = reader["name"].ToString();
                cartItem.IsImported = reader["IsImported"].ToString();
                cartItem.Quantity = (int)reader["quantity"];
                cartItem.UnitPrice = Convert.ToDouble(reader["unitPrice"]);
                cartItem.SubTotal = Convert.ToDouble(reader["SubTotal"]);
                cartItem.TaxedCost = Convert.ToDouble(reader["TaxedCost"]);

                productsAtCart.Add(cartItem);
            }
            return productsAtCart;
        }

        public void ClearCart()
        {
            string query = "delete from CartItems";

            MySqlCommand mySqlCommand = new MySqlCommand(query, this.connection);
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("DatabaseName Error : " + e);
            }

        }

        public void AddToCart(string Name)
        {
            foreach(var product in productList)
            {
                if(product.Name == Name)
                {
                    string query = "INSERT INTO CartItems(name, IsImported, quantity, unitPrice, SubTotal, TaxedCost) VALUES(@name, @IsImported, @quantity,  @unitPrice, @SubTotal, @TaxedCost)";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, this.connection);
                    string ps = "";
                    if (product.Imported) ps = "Imported";
                    else ps = "Local";

                    mySqlCommand.Parameters.AddWithValue("@name", product.Name);
                    mySqlCommand.Parameters.AddWithValue("@IsImported", ps);
                    mySqlCommand.Parameters.AddWithValue("@quantity", product.Quantity);
                    mySqlCommand.Parameters.AddWithValue("@unitPrice", product.Price/product.Quantity);
                    mySqlCommand.Parameters.AddWithValue("@SubTotal", product.Price);
                    mySqlCommand.Parameters.AddWithValue("@TaxedCost", product.TaxedCost+ product.Price);
                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("DatabaseName Error : " + e);
                    }
                    break;
                }
            }
            
        }

        public List<Product> GetAllProduct()
        {
            return productList;
        }

        //Test Data
        public readonly List<Product> productList = new List<Product>
                {


                new BookProduct("book",12.49, false, 1),
                new MiscellaneousProduct("Music CD", 14.99, false, 1),
                new FoodProduct("Chocolate bar", 0.85, false, 1),

                new MiscellaneousProduct("Imported Bottle of Perfume 47.50", 47.50, true, 1),
                new FoodProduct("Imported Chocolate box 10.00", 10.00, true, 1),


                new MiscellaneousProduct("Imported Bottle of Perfume", 27.99, true, 1),
                new MiscellaneousProduct("Bottle of Perfume", 18.99, false, 1),
                new MedicalProduct("Headache pills", 9.75, false, 1),
                new FoodProduct("Imported Chocolate box 11.25", 11.25, true, 1),

            };

    }

}
