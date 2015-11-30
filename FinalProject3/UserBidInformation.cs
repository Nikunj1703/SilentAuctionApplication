namespace FinalProject3
{
    public class UserBidInformation
    {
        public int BidId { get; set; }
        public string Email { get; set; }
        public string ItemId { get; set; }
        public string WinningStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string BidAmount { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }

        public UserBidInformation() { }

        public UserBidInformation(int bidId, string email, string itemId, string winningStatus, string paymentStatus, string bidAmount, string phoneNumber, string name)
        {
            BidId = bidId;
            Email = email;
            ItemId = itemId;
            WinningStatus = winningStatus;
            PaymentStatus = paymentStatus;
            BidAmount = bidAmount;
            PhoneNumber = phoneNumber;
            Name = name;
        }
    }
}