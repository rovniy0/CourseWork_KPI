using System;
using CourseWork.User;
using UI;

namespace CourseWork.UI
{
    public class UserController: IControllerService
    {
        private DataBase.DataBase Data { get; }
        private User.User User { get; }

        public UserController(DataBase.DataBase dataBase, User.User user)
        {
            Data = dataBase;
            User = user;
        }

        public string PrintMessage()
        {
            return " 3. Show personal info";
        }

        public void DoAction()
        {
            var exit = false;
            while (!exit)
            {
                exit = Action();
            }
        }

        private bool Action()
        {
            Console.WriteLine(" 1. Show balance");
            Console.WriteLine(" 2. Increase balance");
            Console.WriteLine(" 3. View purchase history");
            Console.WriteLine(" 4. Exit");
            Console.WriteLine("\n Enter what would you like to do (digit):");
            var option = Console.ReadLine();
            var us = new UserService(Data);
            var exit = false;
            
            if (!string.IsNullOrEmpty(option))
            {
                var action = int.Parse(option);
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Your balance: " + us.GetBalance(User) + "$.");
                        break;
                    case 2:
                        Console.WriteLine("enter the amount:");
                        var value = int.Parse(Console.ReadLine());
                        if (value >= 0)
                        {
                            us.IncreaseBalance(User, value);
                            Console.WriteLine("Your balance: " + us.GetBalance(User) + "$.");
                        }
                        else
                        {
                            Console.WriteLine("Error, sum is incorrect");
                        }
                        break;
                    case 3:
                        var purchases = us.GetHistory(User);
                        if (purchases.Count == 0)
                        {
                            Console.WriteLine("You haven`t done any purchases yet");
                        }
                        else
                        {
                            purchases.ForEach(Console.WriteLine);
                        }
                        break;
                    case 4:
                        return true;
                }
            }

            return false;
        }
    }
}