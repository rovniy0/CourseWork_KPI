using System;
using System.Collections.Generic;
using System.Linq;
using CourseWork.Purchase;

namespace CourseWork.User
{
    public class UserService : IUserService
    {
        private DataBase.DataBase Data { get; }

        public UserService(DataBase.DataBase dataBase)
        {
            Data = dataBase;
        }
        public void CreateUser(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var user = new User(userName, password);
                Data.Users.Add(user);
                Console.WriteLine("User " + userName + " registered successfully");   
                return;
            }

            Console.WriteLine("Error, wrong user name.");
        }

        public User GetUser(string userName)
        {
            if (UserExists(userName))
            {
                return Data.Users.Find(x => x.UserName.Equals(userName));
            }

            return new User("unknown", "qwertyui");
        }

        public bool CheckUsersPassword(string userName, string password)
        {
            var passwordService = new PasswordService(Data);
            var user = GetUser(userName);
            return passwordService.ComparePasswords(user, password);
        }

        public void DeleteUser(string userName)
        {
            if (UserExists(userName))
            {
                var user = GetUser(userName);
                Data.Users.Remove(user);
                Console.WriteLine("User " + userName + " deleted successfully");
                return;
            }

            Console.WriteLine("User " + userName + " was not found");
        }

        public bool UserExists(string userName)
        {
            foreach (var user in Data.Users)
            {
                if (user.UserName.Equals(userName))
                {
                    return true;
                }
            }

            return false;
        }

        public float GetBalance(User user)
        {
            if (UserExists(user.UserName))
            {
                return user.Balance;
            }
            
            return 0;
        }

        public void AddPurchase(User user, PurchaseData purchase)
        {
            if (UserExists(user.UserName))
            {
                user.Purchase.Add(purchase);
            }
        }

        public List<PurchaseData> GetHistory(User user)
        {
            if (UserExists(user.UserName))
            {
                return user.Purchase.ToList();   
            }

            return new List<PurchaseData>();
            // todo purchase wut 
            // todo check if null
        }

        public void IncreaseBalance(User user, float amount)
        {
            if (UserExists(user.UserName))
            {
                user.Balance += amount;
            }
            // todo if sum < 0
        }

        public bool DecreaseBalance(User user, float price, int amount)
        {
            if (price * amount <= user.Balance)
            {
                user.Balance -= price * amount;
                return true;
            }

            return false;
        }
    }
}