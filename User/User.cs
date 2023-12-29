using System;
using System.Collections.Generic;
using CourseWork.Purchase;

namespace CourseWork.User
{
    public class User
    {
        public string UserName { get; }
        public string Password { get; }
        private Guid Id { get; }
        public float Balance { get; set; }
        public List<PurchaseData> Purchase { get; }

        public User(string userName, string password)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
            Balance = 0;
            Purchase = new List<PurchaseData>();
        }

        public override string ToString()
        {
            return "User`s name: " + UserName;
        }
    }
}