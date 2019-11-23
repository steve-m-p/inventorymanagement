using FluentAssertions;
using InventoryManagement.Models;
using InventoryManagement.Rules;
using Xunit;

namespace InventoryManagement.Tests.UnitTests
{
    public class FrozenItemUpdateRuleUnits
    {
        [Fact]
        public void GivenFrozenItem_WhenUpdated_SellinReducesBy1()
        {

            var item = new Item() {Name = "Frozen Item", Quality = 2, SellIn = 2};
            var rule = new FrozenItemUpdateRule();
            rule.Update(item);

            item.SellIn.Should().Be(1);
        }

        [Fact]
        public void GivenFrozenItem_WhenUpdated_QualityReducesBy1()
        {

            var item = new Item() { Name = "Frozen Item", Quality = 2, SellIn = 2 };
            var rule = new FrozenItemUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(1);
        }

        [Fact]
        public void GivenFrozenItem_WhenQualityAlready0_QualityIsNotNegative()
        {

            var item = new Item() { Name = "Frozen Item", Quality = 0, SellIn = 2 };
            var rule = new FrozenItemUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void GivenFrozenItem_WhenQualityMoreThan50_QualityResetTo50()
        {

            var item = new Item() { Name = "Frozen Item", Quality = 55, SellIn = 2 };
            var rule = new FrozenItemUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(50);
        }
        [Fact]
        public void GivenFrozenItem_WhenSellinPast0_QualityReduces2xFaster()
        {

            var item = new Item() { Name = "Frozen Item", Quality = 2, SellIn = -1 };
            var rule = new FrozenItemUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(0);
        }
    }
}