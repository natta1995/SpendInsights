using SQLite;
using SpendInsights.Models;

namespace SpendInsights.Data
{
    public class AppDatabase
    {
        private SQLiteAsyncConnection? _database;

        private async Task Init()
        {
            if (_database is not null)
                return;

            var databasePath = Path.Combine(
                FileSystem.AppDataDirectory,
                "SpendInsights.db");

            _database = new SQLiteAsyncConnection(databasePath);

            await _database.CreateTableAsync<Purchase>();
            await _database.CreateTableAsync<PurchaseItem>();
        }

        public async Task SavePurchaseAsync(Purchase purchase)
        {
            await Init();

            await _database!.InsertAsync(purchase);

            foreach (var item in purchase.Items)
            {
                item.PurchaseId = purchase.Id;
                await _database.InsertAsync(item);
            }

        }

        public async Task<List<Purchase>> GetPurchasesAsync()
        {
            await Init();

            var purchases = await _database!.Table<Purchase>().ToListAsync();

            foreach (var purchase in purchases)
            {
                purchase.Items = await _database
                    .Table<PurchaseItem>()
                    .Where(item => item.PurchaseId == purchase.Id)
                    .ToListAsync();
            }

            return purchases;
        }
    }
}
