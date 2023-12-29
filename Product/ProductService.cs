using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork.Product
{
    public class ProductService : IProductService
    {
        private DataBase.DataBase Data { get; }

        public ProductService(DataBase.DataBase dataBase)
        {
            Data = dataBase;
        }

        public void CreateProduct(string productName, float price, string description, int amount)
        {
            var product = new Product(productName, price, description, amount);
            Data.Products.Add(product);
            Console.WriteLine("Product " + productName + " created successfully");
        }

        public Product GetProduct(string productName)
        {
            if (ProductExists(productName))
            {
                return Data.Products.Find(x => x.Name.Equals(productName));
            }

            return new Product("unknown", 0, "", 0);
        }

        public void DeleteProduct(string productName)
        {
            if (ProductExists(productName))
            {
                var product = GetProduct(productName);
                Data.Products.Remove(product);
                Console.WriteLine("Product " + productName + " deleted successfully");
                return;
            }

            Console.WriteLine("Product " + productName + " was not found");
        }

        public List<Product> GetAllProducts()
        {
            return Data.Products.Select(x => x).ToList();
        }

        public void ShowProducts()
        {
            Data.Products.ForEach(Console.WriteLine);
        }

        public bool ProductExists(string productName)
        {
            foreach (var product in Data.Products)
            {
                if (product.Name.Equals(productName))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddProduct()
        {
            Console.WriteLine("Add the name of the product");
            var name = Console.ReadLine();
            Console.WriteLine("Add the price of the product");
            var priceStr = Console.ReadLine();
            var price = 0f;
            if (!string.IsNullOrEmpty(priceStr))
            {
                price = float.Parse(priceStr);
            }
            Console.WriteLine("Add the description of the product");
            var description = Console.ReadLine();
            Console.WriteLine("Add the amount of the product");
            var amountStr = Console.ReadLine();
            var amount = 0;
            if (!string.IsNullOrEmpty(amountStr))
            {
                amount = int.Parse(amountStr);
            }
            var product = new Product(name, price, description, amount);
            Data.Products.Add(product);
        }

        public bool DecreaseAmount(string productName, int amount)
        {
            var product = GetProduct(productName);
            if (product.Amount < amount)
            {
                return false;
            }
            product.Amount -= amount;
            return true;
        }
        
        public void ChangeAmount(string productName, int newAmount)
        {
            var product = GetProduct(productName);
            if (newAmount < 0)
            {
                product.Price = 0;
                return;
            }
            product.Amount = newAmount;
        }

        public void ChangeDescription(string productName, string newDescription)
        {
            var product = GetProduct(productName);
            product.Description = newDescription;
        }

        public void ChangePrice(string productName, float newPrice)
        {
            var product = GetProduct(productName);
            if (newPrice < 0.99)
            {
                product.Price = 0.99f;
                return;
            }
            product.Price = newPrice;
        }
    }
}