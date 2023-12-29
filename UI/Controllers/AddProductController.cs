using UI;
using CourseWork.Product;

namespace CourseWork.UI
{
    public class AddProductController : IControllerService
    {
        private DataBase.DataBase Data { get; }

        public AddProductController(DataBase.DataBase dataBase)
        {
            Data = dataBase;
        }

        public string PrintMessage()
        {
            return " 1. Add products to the store";
        }

        public void DoAction()
        {
            var ps = new ProductService(Data);
            ps.AddProduct();
        }
    }
}