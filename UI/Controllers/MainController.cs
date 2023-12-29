using System;
using System.Collections.Generic;
using UI;

namespace CourseWork.UI  //todo реалізувати інтерфейс контролеру і додати метод шоу "авторизуйся" після чого в ду робити авторизацію поки не пройде, а потім надати доступ до інших опцій
{
    public class MainController
    {
        private List<IControllerService> UIs { get; }
        private DataBase.DataBase Data { get; }

        private User.User User { get; set; }
        private bool IsAuthorized { get; }

        public MainController()
        {
            Data = new DataBase.DataBase();
            new DataBaseController(Data);
            IsAuthorized = GotAuthorized(Data);
            UIs = new List<IControllerService>(8);
            UIs.Add(new AddProductController(Data));
            UIs.Add(new BuyProductController(Data, User));
            UIs.Add(new UserController(Data, User));
            UIs.Add(new ShowProductController(Data));
            UIs.Add(new ExitController(Data));
        }

        public void RunProgram()
        {
            if (IsAuthorized)
            {
                while (true)
                {
                    ShowActions();
                    DoAction();
                }
            }
        }

        private bool GotAuthorized(DataBase.DataBase dataBase)
        {
            var auto = new AuthorizationController(dataBase);
            var access = false;
            while (access == false)
            {
                auto.DoAction();
                User = auto.GetUser();
                access = auto.GetState();
            }

            return true;
        }

        private void ShowActions()
        {
            Console.WriteLine("  Choose options:\n");
            foreach (var option in UIs)
            {
                Console.WriteLine(option.PrintMessage());
            }
        }

        private void DoAction()
        {
            Console.WriteLine("\n Enter what would you like to do (digit):");
            var option = Console.ReadLine();

            if (!string.IsNullOrEmpty(option))
            {
                var action = int.Parse(option);
                switch (action)
                {
                    case 1:
                        UIs[0].DoAction();
                        break;
                    case 2:
                        UIs[1].DoAction();
                        break;
                    case 3:
                        UIs[2].DoAction();
                        break;
                    case 4:
                        UIs[3].DoAction();
                        break;
                    case 5:
                        UIs[4].DoAction();
                        break;
                }
            }  // todo action massage equals enum == number from dict?
        }
    }
}