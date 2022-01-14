using System.ComponentModel.DataAnnotations;

namespace ShopModels.Models
{
    public class ProductsSellOrder
    {
        [Display(Name = "Product Type")]
        public string ProductType { get; set; }

        public int Quantity { get; set; }
    }
}