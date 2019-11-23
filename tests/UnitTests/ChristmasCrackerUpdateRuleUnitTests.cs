using FluentAssertions;
using InventoryManagement.Models;
using InventoryManagement.Rules;
using Xunit;

namespace InventoryManagement.Tests.UnitTests
{
    public class ChristmasCrackerUpdateRuleUnitTests
    {

        //"Christmas Crackers", like “Aged Brie”, increases in Quality as its SellIn value approaches; Its
        //quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
        //but quality drops to 0 after Christmas
        [Fact]
        public void GivenChristmasCrackers_WhenUpdated_SellinReducesByOne()
        {

            var item = new Item() {Name = "Christmas Crackers", Quality = 2, SellIn = 2};
            var rule = new ChristmasCrackerUpdateRule();
            rule.Update(item);

            item.SellIn.Should().Be(1);
        }

        [Fact]
        public void GivenChristmasCrackers_WhenSellinBetween10and5Days_QualityIncreasesBy2()
        {

            var item = new Item() { Name = "Christmas Crackers", Quality = 2, SellIn = 7 };
            var rule = new ChristmasCrackerUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(4);
        }
        
        [Fact]
        public void GivenChristmasCrackers_WhenSellinBetween5And0Days_QualityIncreasesBy3()
        {

            var item = new Item() { Name = "Christmas Crackers", Quality = 2, SellIn = 3 };
            var rule = new ChristmasCrackerUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(5);
        }

        [Fact]
        public void GivenChristmasCrackers_WhenSellinPastChristmas_QualityZero()
        {

            var item = new Item() { Name = "Christmas Crackers", Quality = 2, SellIn = -1 };
            var rule = new ChristmasCrackerUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(0);
        }


    }
}