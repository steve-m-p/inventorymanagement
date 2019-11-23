using FluentAssertions;
using InventoryManagement.Models;
using InventoryManagement.Rules;
using Xunit;

namespace InventoryManagement.Tests
{
    public class FreshItemUpdateRuleUnits
    {
        [Fact]
        public void GivenFreshItem_WhenUpdated_SellinReducesBy1()
        {

            var item = new Item() {Name = "Fresh Item", Quality = 2, SellIn = 2};
            var rule = new FreshItemUpdateRule();
            rule.Update(item);

            item.SellIn.Should().Be(1);
        }

        [Fact]
        public void GivenFreshItem_WhenUpdated_QualityReducesBy2()
        {

            var item = new Item() { Name = "Fresh Item", Quality = 2, SellIn = 2 };
            var rule = new FreshItemUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void GivenFreshItem_WhenQualityAlready0_QualityIsNotNegative()
        {

            var item = new Item() { Name = "Fresh Item", Quality = 0, SellIn = 2 };
            var rule = new FreshItemUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void GivenFreshItem_WhenQualityMoreThan50_QualityResetTo50()
        {

            var item = new Item() { Name = "Fresh Item", Quality = 55, SellIn = 2 };
            var rule = new FreshItemUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(50);
        }
        [Fact]
        public void GivenFreshItem_WhenSellinPast0_QualityReduces2xFaster()
        {

            var item = new Item() { Name = "Fresh Item", Quality = 4, SellIn = -1 };
            var rule = new FreshItemUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(0);
        }
    }
}