using FluentAssertions;
using InventoryManagement.Models;
using InventoryManagement.Rules;
using Xunit;

namespace InventoryManagement.Tests
{
    public class SoapUpdateRuleUnitTests
    {
        [Fact]
        public void GivenSoap_WhenUpdated_SellinStaysTheSame()
        {

            var item = new Item() {Name = "Soap", Quality = 2, SellIn = 2};
            var rule = new SoapUpdateRule();
            rule.Update(item);

            item.SellIn.Should().Be(2);
        }

        [Fact]
        public void GivenSoap_WhenUpdated_QualityStaysTheSame()
        {

            var item = new Item() { Name = "Soap", Quality = 2, SellIn = 2 };
            var rule = new SoapUpdateRule();
            rule.Update(item);

            item.Quality.Should().Be(2);
        }


    }
}