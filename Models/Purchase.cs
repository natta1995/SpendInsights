
namespace SpendInsights.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public string StoreName { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;

        public DateTime PurchaseDate { get; set; } = DateTime.Today;

        public List<PurchaseItem> Items { get; set; } = [];

    }
}
