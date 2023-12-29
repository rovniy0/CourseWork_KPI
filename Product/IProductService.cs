using System.Collections.Generic;

namespace CourseWork.Product
{
    public interface IProductService
    {
        void CreateProduct(string productName, float price, string description, int amount);
        Product GetProduct(string productName);
        void DeleteProduct(string productName);
        bool ProductExists(string productName);
        List<Product> GetAllProducts();
        void ShowProducts();
        void AddProduct();
        bool DecreaseAmount(string productName, int amount);
        void ChangeAmount(string productName, int newAmount);
        void ChangeDescription(string productName, string newDescription);
        void ChangePrice(string productName, float newPrice);
    }
}