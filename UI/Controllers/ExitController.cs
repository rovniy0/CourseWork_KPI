using System;
using UI;

namespace CourseWork.UI
{
    public class ExitController : IControllerService
    {
        private DataBase.DataBase Data { get; }

        public ExitController(DataBase.DataBase dataBase)
        {
            Data = dataBase;
        }
        public string PrintMessage()
        {
            return " 5. Stop the program";
        }

        public void DoAction()
        {
            var dataBaseControllerController = new DataBaseController(Data);
            dataBaseControllerController.CloseDb();
            throw new Exception("\n----Stopping the program----\n");
        }
    }
}