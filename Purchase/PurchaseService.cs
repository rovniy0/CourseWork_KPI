using System;
using System.Collections.Generic;
using CourseWork.Product;
using CourseWork.User;

namespace CourseWork.Purchase
{
    public class PurchaseService
    {
        private ProductService ProductService { get; }
        private UserService UserService { get; }

        public PurchaseService(DataBase.DataBase dataBase)
        {
            ProductService = new ProductService(dataBase);
            UserService = new UserService(dataBase);
        }

        public void Buy(User.User user)
        {
            ShowInfo();
            Console.WriteLine("Enter what would you like to buy: ");
            var product = Console.ReadLine();
            if (!string.IsNullOrEmpty(product) && CheckProduct(product))
            {
                var amount = 0;
                Console.WriteLine("Enter the amount you want to buy: ");
                var amountStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(amountStr))
                {
                    amount = int.Parse(amountStr);
                }
                var success = DoBuy(user, product, amount);
                if (success)
                {
                    var purchase = new PurchaseData(product, ProductService.GetProduct(product).Price, amount);
                    UserService.AddPurchase(user, purchase);
                    Console.WriteLine("Product bought successfully");
                    return;
                }
                Console.WriteLine("Error, not enough items or amount of money");
            }

            Console.WriteLine("Incorrect product name!");
        }

        private bool DoBuy(User.User user, string productName, int amount)
        {
            var product = ProductService.GetProduct(productName);
            if (ProductService.DecreaseAmount(productName, amount) == false)
            {
                return false;
            }
            return UserService.DecreaseBalance(user, product.Price, product.Amount);
        }

        private void ShowInfo()
        {
            Console.WriteLine("Available products:");
            ProductService.ShowProducts();
        }

        private bool CheckProduct(string productName)
        {
            var names = GetProductsName();
            foreach (var product in names)
            {
                if (product.Equals(productName))
                {
                    return true;
                }
            }

            return false;
        }

        private List<string> GetProductsName() // todo product service?
        {
            var products = ProductService.GetAllProducts();
            var productsName = new List<string>();
            foreach (var product in products)
            {
                productsName.Add(product.Name);
            }

            return productsName;
        }
    }
}