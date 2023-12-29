using CourseWork.Purchase;
using UI;

namespace CourseWork.UI
{
    public class BuyProductController : IControllerService
    {
        private DataBase.DataBase Data { get; }
        private User.User User { get; }

        public BuyProductController(DataBase.DataBase dataBase, User.User user)
        {
            Data = dataBase;
            User = user;
        }

        public string PrintMessage()
        {
            return " 2. Buy products";
        }

        public void DoAction()
        {
            var ps = new PurchaseService(Data);
            ps.Buy(User);
        }
    }
}