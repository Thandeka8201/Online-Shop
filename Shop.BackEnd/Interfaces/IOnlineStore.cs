using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BackEnd.Interfaces
{
    public interface IOnlineStore
    {
        void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder);

        ProductsSoldResult SellProductsFromInventory(ProductsSellOrder itemsSoldOrder);

        List<InventoryItemSummary> GetInventoryItemSummary(ProductType stockType);

        List<InventorySummary> GetInventorySummary();
    }
}
