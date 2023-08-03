namespace cards.Models
{
    public class DiscoverDB
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        public string ProductType { get; set; } = null!;

        public float CurrentTag { get; set; }

        public float PreviousTag { get; set; }

        public string SellerReputation { get; set; } = null!;

    }
}
