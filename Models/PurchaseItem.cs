
namespace SpendInsights.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public int Amount { get; set; } = 1;

        public decimal Price { get; set; }

        public double? Weight { get; set; }
    }
}
