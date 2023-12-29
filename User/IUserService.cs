using System.Collections.Generic;
using CourseWork.Purchase;

namespace CourseWork.User
{
    public interface IUserService
    {
        void CreateUser(string userName, string password);
        User GetUser(string userName);
        bool CheckUsersPassword(string userName, string password);
        void DeleteUser(string userName);
        bool UserExists(string userName);
        float GetBalance(User user);
        void AddPurchase(User user, PurchaseData purchase);
        List<PurchaseData> GetHistory(User user);
        void IncreaseBalance(User user, float amount);
        bool DecreaseBalance(User user, float price, int amount);
    }
}