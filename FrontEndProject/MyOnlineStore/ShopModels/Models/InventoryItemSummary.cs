namespace ShopModels.Models
{
    public class InventoryItemSummary
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}