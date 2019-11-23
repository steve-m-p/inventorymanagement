using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using InventoryManagement.Models;
using InventoryManagement.Rules;
using InventoryManagement.Services;
using Xunit;

namespace InventoryManagement.Tests.AcceptanceTests
{
    public class AcceptanceTests
    {
        private IInventoryManagementService _inventoryManagementService;

        [Fact]
        public void GivenAgedBrie_SellIn1_Quality1_WhenUpdated_ThenAgedBrie_SellIn0_Quality2_Returned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "Aged Brie", SellIn = 1, Quality = 1}
            };
            var rule = new AgedBrieUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("Aged Brie 0 2");
        }

        [Fact]
        public void
            GivenChristmasCrackers_SellInMinus1_Quality2_WhenUpdated_ThenChristmasCrackers_SellInMinus2_Quality0_Returned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "Christmas Crackers", SellIn = -1, Quality = 2}
            };
            var rule = new ChristmasCrackerUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("Christmas Crackers -2 0");
        }

        [Fact]
        public void
            GivenChristmasCrackers_SellIn9_Quality2_WhenUpdated_ThenChristmasCrackers_SellIn8_Quality4_Returned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "Christmas Crackers", SellIn = 9, Quality = 2}
            };
            var rule = new ChristmasCrackerUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("Christmas Crackers 8 4");
        }

        [Fact]
        public void GivenSoap_SellIn2_Quality2_WhenUpdated_ThenSoap_SellIn2_Quality2_Returned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "Soap", SellIn = 2, Quality = 2}
            };
            var rule = new SoapUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("Soap 2 2");
        }

        [Fact]
        public void GivenFrozenItem_SellInMinus1_Quality55_WhenUpdated_ThenFrozenItem_SellInMinus2_Quality50_Returned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "Frozen Item", SellIn = -1, Quality = 55}
            };
            var rule = new FrozenItemUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("Frozen Item -2 50");
          
        }

        [Fact]
        public void GivenFrozenItem_SellIn2_Quality2_WhenUpdated_ThenFrozenItem_SellIn1_Quality1_Returned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "Frozen Item", SellIn = 2, Quality = 2}
            };
            var rule = new FrozenItemUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("Frozen Item 1 1");
        }

        [Fact]
        public void GivenINVALIDITEM_SellIn2_Quality2_WhenUpdated_ThenNOSUCHITEMReturned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "INVALID ITEM", SellIn = 2, Quality = 2}
            };
            var rule = new SoapUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("NO SUCH ITEM");
        }

        [Fact]
        public void GivenFreshItem_SellIn2_Quality2_WhenUpdated_ThenFreshItem_SellIn1_Quality0_Returned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "Fresh Item", SellIn = 2, Quality = 2}
            };
            var rule = new FreshItemUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("Fresh Item 1 0");
        }

        [Fact]
        public void GivenFreshItem_SellInMinus1_Quality5_WhenUpdated_ThenFreshItem_SellInMinus2_Quality1_Returned()
        {
            //GIVEN
            var items = new List<Item>()
            {
                new Item() {Name = "Fresh Item", SellIn = -1, Quality = 5}
            };
            var rule = new FreshItemUpdateRule();
            _inventoryManagementService = new InventoryManagementService(updateRule => rule);
            //WHEN
            var results = _inventoryManagementService.Update(items);
            //THEN
            var result = results.First();
            result.Should().Be("Fresh Item -2 1");
        }
    }
}