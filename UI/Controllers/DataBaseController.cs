using CourseWork.DataBase;
using UI;

namespace CourseWork.UI
{
    public class DataBaseController : IControllerService // TODO в конструктор бд запхати звернення до бд
    {
        private DataBase.DataBase Data { get; }
        private ParseInfo Parser { get; }

        public DataBaseController(DataBase.DataBase dataBase)
        {
            Parser = new ParseInfo();
            Data = dataBase;
            DoAction();
        }

        public string PrintMessage()
        {
            return "";
        }

        public void DoAction()
        {
            InvokeProductsDb();
            InvokeUsersDb();
        }

        public void CloseDb()
        {
            SleepProductsDb();
            SleepUsersDb();
        }

        private void InvokeProductsDb()
        {
            var products = Parser.ReadProductsFromDb();
            foreach (var product in products)
            {
                Data.Products.Add(product);
            }
        }

        private void InvokeUsersDb()
        {
            var users = Parser.ReadUsersFromDb();
            foreach (var user in users)
            {
                Data.Users.Add(user);
            } // todo safe method
        }
        
        private void SleepProductsDb()
        {
            Parser.SaveAllProductsToDb(Data);
        }

        private void SleepUsersDb()
        {
            Parser.SaveAllUsersToDb(Data);
        }
    }
}