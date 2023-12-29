using System.Collections.Generic;

namespace CourseWork.DataBase
{
    public class DataBase  // TODO make static?
    {
        public List<User.User> Users { get; }
        public List<Product.Product> Products { get; }

        public DataBase()
        {
            Users = new List<User.User>();
            Products = new List<Product.Product>();
        }
    }
}