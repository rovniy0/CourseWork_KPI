using CourseWork.Product;
using UI;

namespace CourseWork.UI
{
    public class ShowProductController : IControllerService
    {
        private DataBase.DataBase Db { get; }

        public ShowProductController(DataBase.DataBase dataBase)
        {
            Db = dataBase;
        }

        public string PrintMessage()
        {
            return " 4. Show available products";
        }

        public void DoAction() 
        {
            var ps = new ProductService(Db);
            ps.ShowProducts();
        }
    }
}