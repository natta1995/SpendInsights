
using SQLite;

namespace SpendInsights.Models
{

    public class Purchase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string StoreName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; } = DateTime.Today;

        [Ignore]
        public List<PurchaseItem> Items { get; set; } = [];

        [Ignore]
        public decimal TotalSum => Items.Sum(item => item.Price);
    }
}
