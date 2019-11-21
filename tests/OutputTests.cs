using FluentAssertions;
using InventoryManagement.Models;
using InventoryManagement.Services;
using Xunit;

namespace InventoryManagement.UnitTests
{
    public class OutputTests
    {
        private IInventoryManagementService _inventoryManagementService = new Services.InventoryManagementService();

        [Fact]
        public void GivenAgedBrie_SellIn1_Quality1_WhenUpdated_ThenAgedBrie_SellIn0_Quality2_Returned()
        {
            //GIVEN
            var item = new Item() {Name = "Aged Brie", SellIn = 1, Quality = 1};
            //WHEN
            var result =_inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Aged Brie");
            result.SellIn.Should().Be(2);
            result.Quality.Should().Be(0);
        }
        [Fact]
        public void GivenChristmasCrackers_SellInMinus1_Quality2_WhenUpdated_ThenChristmasCrackers_SellInMinus2_Quality0_Returned()
        {
            //GIVEN
            var item = new Item() { Name = "Christmas Crackers", SellIn = -1, Quality = 2 };
            //WHEN
            var result = _inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Christmas Crackers");
            result.SellIn.Should().Be(-2);
            result.Quality.Should().Be(0);
        }
        [Fact]
        public void GivenChristmasCrackers_SellIn9_Quality2_WhenUpdated_ThenChristmasCrackers_SellIn8_Quality4_Returned()
        {
            //GIVEN
            var item = new Item() { Name = "Christmas Crackers", SellIn = 9, Quality = 2 };
            //WHEN
            var result = _inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Christmas Crackers");
            result.SellIn.Should().Be(8);
            result.Quality.Should().Be(4);
        }
        [Fact]
        public void GivenSoap_SellIn2_Quality2_WhenUpdated_ThenSoap_SellIn2_Quality2_Returned()
        {
            //GIVEN
            var item = new Item() { Name = "Soap", SellIn = 2, Quality = 2 };
            //WHEN
            var result = _inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Soap");
            result.SellIn.Should().Be(2);
            result.Quality.Should().Be(2);
        }

        [Fact]
        public void GivenFrozenItem_SellInMinus1_Quality55_WhenUpdated_ThenFrozenItem_SellInMinus2_Quality50_Returned()
        {
            //GIVEN
            var item = new Item() { Name = "Frozen Item", SellIn = -1, Quality = 50 };
            //WHEN
            var result = _inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Frozen Item");
            result.SellIn.Should().Be(-1);
            result.Quality.Should().Be(50);
        }
        [Fact]
        public void GivenFrozenItem_SellIn2_Quality2_WhenUpdated_ThenFrozenItem_SellIn1_Quality1_Returned()
        {
            //GIVEN
            var item = new Item() { Name = "Frozen Item", SellIn = 2, Quality = 2 };
            //WHEN
            var result = _inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Frozen Item");
            result.SellIn.Should().Be(1);
            result.Quality.Should().Be(1);
        }
        [Fact]
        public void GivenINVALIDITEM_SellIn2_Quality2_WhenUpdated_ThenNOSUCHITEMReturned()
        {
            //GIVEN
            var item = new Item() { Name = "INVALID ITEM", SellIn = 2, Quality = 2 };
            //WHEN
            var result = _inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Frozen Item");
            result.SellIn.Should().Be(1);
            result.Quality.Should().Be(1);
        }
        [Fact]
        public void GivenFreshItem_SellIn2_Quality2_WhenUpdated_ThenFreshItem_SellIn1_Quality0_Returned()
        {
            //GIVEN
            var item = new Item() { Name = "Fresh Item", SellIn = 2, Quality = 2 };
            //WHEN
            var result = _inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Fresh Item");
            result.SellIn.Should().Be(1);
            result.Quality.Should().Be(0);
        }
        [Fact]
        public void GivenFreshItem_SellInMinus1_Quality5_WhenUpdated_ThenFreshItem_SellInMinus2_Quality1_Returned()
        {
            //GIVEN
            var item = new Item() { Name = "Fresh Item", SellIn = -1, Quality = 5 };
            //WHEN
            var result = _inventoryManagementService.Update(item);
            //THEN
            result.Name.Should().Be("Fresh Item");
            result.SellIn.Should().Be(-2);
            result.Quality.Should().Be(1);
        }

    }
}
