using ShopModels.Models;

namespace ShopBackEnd.Interfaces
{
    public interface IOnlineStoreService
    {
        void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder);

        ProductsSoldResult SellProductsFromInventory(ProductsSellOrder itemsSoldOrder);

        InventoryItemSummary GetInventoryItemSummary(ProductType StockType);

        InventorySummary GetInventorySummary();

        InventoryItemSummary GetInventoryItemSummary(int id);

    }
}
