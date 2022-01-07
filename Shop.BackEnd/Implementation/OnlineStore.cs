using Shop.BackEnd.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Shop.BackEnd.DataAccess;

namespace Shop.BackEnd.Implementation
{
    public class OnlineStoreLogic : IOnlineStore
    {
        

        public OnlineStoreLogic()
        {
            
        }

        public void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder)
        {
            var sqlConn = SqlServerConnection.GetSqlConnection();  //connects to the database
            sqlConn.Open();
            SqlCommand command = new SqlCommand ("INSERT INTO Purchase_Order " + 
                "(ProductType,BrandName,Quantity,Price)" + 
                "VALUES('"+purchaseOrder.productType+"', '"+purchaseOrder.productBrand+"', '"+purchaseOrder.productQuantity+"', '"+purchaseOrder.productPrice+"')", sqlConn);
            command.ExecuteNonQuery();
            sqlConn.Close();
        }

        public List<InventoryItemSummary> GetInventoryItemSummary(ProductType stockType)
        {
            var itemList = new List<InventoryItemSummary>();
            var sqlConn = SqlServerConnection.GetSqlConnection();  //connects to the database

            sqlConn.Open();
            SqlCommand sql = new SqlCommand("Select * From Purchase_Order Where ProductType = '"+stockType.Name+"'", sqlConn);
            using (SqlDataReader sqlReader = sql.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    var item = new InventoryItemSummary();
                    var dt = sqlReader["Quantity"];
                    var dt1 = sqlReader["Price"];
                    var dt2 = sqlReader["BrandName"];
                    item.Quantity = int.Parse(dt.ToString());
                    item.Price = double.Parse(dt1.ToString());
                    item.BrandName = dt2.ToString();
                    itemList.Add(item);
                }
            };
            sql.ExecuteNonQuery();
            sqlConn.Close();

            return itemList; 
        }

        public List<InventorySummary> GetInventorySummary()
        {
            var inventorySummaryList = new List<InventorySummary>();

            var laptops = GetInventoryItemSummary(new ProductType { Name = "Laptops"});
            var tablets = GetInventoryItemSummary(new ProductType { Name = "Tablets"});
            var phones = GetInventoryItemSummary(new ProductType { Name = "Phones"});
            inventorySummaryList.AddRange((IEnumerable<InventorySummary>)phones);
            inventorySummaryList.AddRange((IEnumerable<InventorySummary>)laptops);
            inventorySummaryList.AddRange((IEnumerable<InventorySummary>)tablets);
            return inventorySummaryList;
        }

        public ProductsSoldResult SellProductsFromInventory(ProductsSellOrder itemsSoldOrder)
        {
            var product = new ProductType { Name = itemsSoldOrder.productType};
            var productStock = GetInventoryItemSummary(product);
            //get total quantity
            int productSum = 0;
            foreach (var productList in productStock)
            {
                productSum += productList.Quantity;
            }
            // checks if there is enough stock
            if (productSum < itemsSoldOrder.productQuantity)
            {
                return new ProductsSoldResult
                { OrderCompleted = false,
                  Message = "Sorry, not enough stock!"
                };
            }
            else
            {
                updateDatabase(productStock, itemsSoldOrder.productQuantity);           
                return new ProductsSoldResult
                { OrderCompleted = true,
                  Message = "Thank you for buying from us!"
                };
            }
            
        }
        public List<StockToUpdate> updateDatabase(List<InventoryItemSummary> stock, int quantity)
        {
            var stockUpdates = new List<StockToUpdate>();
            foreach (var brand in stock)
            {
                if (brand.Quantity > 0  && quantity > 0)
                {
                    var stockUpdt = new StockToUpdate
                    {
                        BrandName = brand.BrandName,
                        Quantity = brand.Quantity - quantity
                    };
                    stockUpdates.Add(stockUpdt);
                    quantity -= brand.Quantity;
                    updateBrandQuantity(stockUpdt);
                }
                
            }
            return stockUpdates;
        }

        public void updateBrandQuantity(StockToUpdate stockToUpdate)
        {
            //sell and update remaining quantity
            var sqlConn = SqlServerConnection.GetSqlConnection();  //connects to the database
            sqlConn.Open();
            SqlCommand sql = new SqlCommand($"UPDATE Purchase_Order " +
                $"SET Quantity = {stockToUpdate.Quantity}" +
                $"WHERE BrandName = {stockToUpdate.BrandName}", sqlConn);
            sql.ExecuteNonQuery();
            sqlConn.Close();
        }
    }
}
