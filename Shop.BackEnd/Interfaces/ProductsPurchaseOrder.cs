namespace Shop.BackEnd.Interfaces
{
    public class ProductsPurchaseOrder
    {
        public string productType { get; set; }
        public string productBrand { get; set; }
        public double productPrice { get; set; }
        public int productQuantity { get; set; }
    }
}