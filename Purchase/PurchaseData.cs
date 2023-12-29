using System;

namespace CourseWork.Purchase
{
    public class PurchaseData
    {
        private string PurchasedItem { get; }
        private float PurchasedPrice { get; }
        private int PurchasedAmount { get; }
        private DateTime Date { get; }

        public PurchaseData(string purchasedItem, float purchasedPrice, int purchasedAmount)
        {
            PurchasedItem = purchasedItem;
            PurchasedPrice = purchasedPrice;
            PurchasedAmount = purchasedAmount;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return PurchasedItem + ". Price: " + PurchasedPrice + ". Amount: " + PurchasedAmount + ". Date:" + Date;
        }
    }
}