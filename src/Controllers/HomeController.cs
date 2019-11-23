using System.Collections.Generic;
using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IInventoryManagementService _inventoryManagementService;

        public HomeController(IInventoryManagementService inventoryManagementService)
        {
            _inventoryManagementService = inventoryManagementService;
        }

        public IActionResult Index()
        {
            var items = new List<Item>()
            {
                new Item() {Name = "Aged Brie", SellIn = 1, Quality = 1},
                new Item() {Name = "Christmas Crackers", SellIn = -1, Quality = 2},
                new Item() {Name = "Christmas Crackers", SellIn = 9, Quality = 2},
                new Item() {Name = "Soap", SellIn = 2, Quality = 2},
                new Item() {Name = "Frozen Item", SellIn = -1, Quality = 55},
                new Item() {Name = "Frozen Item", SellIn = 2, Quality = 2},
                new Item() {Name = "INVALID ITEM", SellIn = 2, Quality = 2},
                new Item() {Name = "Fresh Item", SellIn = 2, Quality = 2},
                new Item() {Name = "Fresh Item", SellIn = -1, Quality = 5}
            };

            var viewModel = new ItemsViewModel() {Items = items};

            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult Update([FromBody] List<Item> items)
        {
            var results = _inventoryManagementService.Update(items);

            return Ok(results);
        }
    }
}