using System.Collections.Generic;
using System.Web.Mvc;
using ShopBackEnd.Implementation;
using ShopBackEnd.Interfaces;
using ShopModels.Models;

namespace MyOnlineStore.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private readonly IOnlineStoreService _onlineStoreService;

        public PurchaseOrdersController()
        {
            _onlineStoreService = new OnlineStoreService();
        }

        // GET: PurchaseOrders
        public ActionResult Index()
        {
            return View();
        }

        // GET: PurchaseOrders/Details/5
        public ActionResult Details(int? id)
        {

            return View();
        }

        // GET: PurchaseOrders/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmedCreate()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmedSold()
        {
            return View();
        }
        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsPurchaseOrder purchaseOrder)
        {
            _onlineStoreService.AddProductsToInventory(purchaseOrder);
            return View("ConfirmedCreate");
        }

        // GET: PurchaseOrders/Edit/5
        public ActionResult InventoryItemSummary(int? id)
        {
            var inventoryItemSummary = _onlineStoreService.GetInventoryItemSummary(id.Value);
            return View(inventoryItemSummary);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsPurchaseOrder purchaseOrder)
        {

            return View();
        }

        //SummaryofInventory
        public ActionResult SummaryofInventory()
        {
            var list = new List<InventoryItemSummary>();
            var laptops = _onlineStoreService.GetInventoryItemSummary(new ProductType
            {
                Name = "Laptops"
            });
            list.Add(laptops);
            var tablets = _onlineStoreService.GetInventoryItemSummary(new ProductType
            {
                Name = "Tablets"
            });
            list.Add(tablets);
            var phones = _onlineStoreService.GetInventoryItemSummary(new ProductType
            {
                Name = "Phones"
            });
            list.Add(phones);
            return View(list);
        }

        //BuyProduct
        [HttpPost]
        public ActionResult BuyProduct(ProductsSellOrder sellOrder)
        {
            var productSold = _onlineStoreService.SellProductsFromInventory(sellOrder);
            return View("SalesResults", productSold);
        }

        [HttpGet]
        public ActionResult BuyProduct()
        {
            return View();
        }
    }
}
