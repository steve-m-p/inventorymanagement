using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using InventoryManagement.Models;
using InventoryManagement.Rules;
using Xunit;

namespace InventoryManagement.Tests
{
    public class AgedBrieUpdateRuleUnitTests
    {
        [Fact]
        public void GivenAgedBrie_WhenUpdated_SellinReducesByOne()
        {

            var item = new Item() {Name = "Aged Brie", Quality = 2, SellIn = 2};
            var rule = new AgedBrieUpdateRule();
            rule.Update(item);

            item.SellIn.Should().Be(1);
        }

        [Fact]
        public void GivenAgedBrie_WhenUpdated_QualityIncreases()
        {

            var item = new Item() { Name = "Aged Brie", Quality = 2, SellIn = 2 };
            var rule = new AgedBrieUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(3);
        }
        

    }
}
