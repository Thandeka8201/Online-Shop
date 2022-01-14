using System.Data.SqlClient;
using ShopBackEnd.DataAccess;
using ShopBackEnd.Interfaces;
using ShopModels.Models;

namespace ShopBackEnd.Implementation
{
    public class OnlineStoreService : IOnlineStoreService
    {
        public void AddProductsToInventory(ProductsPurchaseOrder purchaseOrder)
        {
            var sqlConn = SqlServerConnection.GetSqlConnection();  //connects to the database
            sqlConn.Open();
            SqlCommand command = new SqlCommand("INSERT INTO PurchaseOrder " +
                "(ProductType,Quantity,Price)" +
                "VALUES('" + purchaseOrder.ProductType + "', '" + purchaseOrder.Quantity + "', '" + purchaseOrder.Price + "')", sqlConn);
            command.ExecuteNonQuery();
            sqlConn.Close();
        }

        public InventoryItemSummary GetInventoryItemSummary(ProductType StockType)
        {
            var sqlConn = SqlServerConnection.GetSqlConnection();  //connects to the database

            sqlConn.Open();
            SqlCommand sql = new SqlCommand("Select * From PurchaseOrder Where ProductType = '" + StockType.Name + "'", sqlConn);
            using (SqlDataReader sqlReader = sql.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    var item = new InventoryItemSummary();
                    var dt = sqlReader["Quantity"];
                    var dt1 = sqlReader["Price"];
                    var dt2 = sqlReader["ProductType"];
                    var dt3 = sqlReader["ProductId"];
                    item.Quantity = int.Parse(dt.ToString());
                    item.Price = double.Parse(dt1.ToString());
                    item.Type = dt2.ToString();
                    item.Id = int.Parse(dt3.ToString());
                    return item;
                }
            };
            sql.ExecuteNonQuery();
            sqlConn.Close();

            return null;
        }

        public InventoryItemSummary GetInventoryItemSummary(int id)
        {
            var sqlConn = SqlServerConnection.GetSqlConnection();  //connects to the database

            sqlConn.Open();
            SqlCommand sql = new SqlCommand("Select * From PurchaseOrder Where ProductId = '" + id + "'", sqlConn);
            using (SqlDataReader sqlReader = sql.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    var item = new InventoryItemSummary();
                    var dt = sqlReader["Quantity"];
                    var dt1 = sqlReader["Price"];
                    var dt2 = sqlReader["ProductType"];
                    var dt3 = sqlReader["ProductId"];
                    item.Quantity = int.Parse(dt.ToString());
                    item.Price = double.Parse(dt1.ToString());
                    item.Type = dt2.ToString();
                    item.Id = int.Parse(dt3.ToString());
                    return item;
                }
            };
            sql.ExecuteNonQuery();
            sqlConn.Close();

            return null;
        }

        public InventorySummary GetInventorySummary()
        {
            return null;
        }

        public ProductsSoldResult SellProductsFromInventory(ProductsSellOrder itemsSoldOrder)
        {
            var productItem = GetInventoryItemSummary(new ProductType
            {
               Name = itemsSoldOrder.ProductType
            });

            if (productItem!= null && productItem.Quantity  >= itemsSoldOrder.Quantity)
            {
                var sqlConn = SqlServerConnection.GetSqlConnection();  //connects to the database
                sqlConn.Open();
                var remainingQuantity = productItem.Quantity - itemsSoldOrder.Quantity;
                SqlCommand sql = new SqlCommand($"UPDATE PurchaseOrder " +
                    $"SET Quantity = '{remainingQuantity}'" +
                    $"WHERE ProductType = '{itemsSoldOrder.ProductType}'", sqlConn);
                sql.ExecuteNonQuery();
                sqlConn.Close();
                return new ProductsSoldResult { OrderCompleted = true};
            }

            return new ProductsSoldResult { OrderCompleted = false };
        }
    }
 }
    
