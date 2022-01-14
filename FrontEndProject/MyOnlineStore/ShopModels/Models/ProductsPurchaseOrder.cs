using System.ComponentModel.DataAnnotations;

namespace ShopModels.Models
{
    public class ProductsPurchaseOrder
    {
        [Display(Name = "Product Type")]
        public string ProductType { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}