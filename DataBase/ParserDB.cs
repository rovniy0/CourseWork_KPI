using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CourseWork.DataBase
{
    public class ParseInfo
    {
        private string _filePath =
            @"C:\Users\Юзер\Desktop\Online-shop\DataBase\Files\";

        public void SaveAllProductsToDb(DataBase dataBase)
        {
            var path = string.Concat(_filePath, "Products.json");
            var serialized = JsonConvert.SerializeObject(dataBase.Products);
            File.WriteAllText(path, serialized);
        }

        public void SaveAllUsersToDb(DataBase dataBase)
        {
            var path = string.Concat(_filePath, "Users.json");
            var serialized = JsonConvert.SerializeObject(dataBase.Users);
            File.WriteAllText(path, serialized);
        }

        public List<Product.Product> ReadProductsFromDb()
        {
            var path = string.Concat(_filePath, "Products.json");
            var products = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Product.Product>>(products);
        }

        public List<User.User> ReadUsersFromDb()
        {
            var path = string.Concat(_filePath, "Users.json");
            var users = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<User.User>>(users);
        }
    }
}