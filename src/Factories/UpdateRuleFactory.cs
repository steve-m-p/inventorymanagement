using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;
using InventoryManagement.Rules;

namespace InventoryManagement.Factories
{
    public class UpdateRuleFactory : IUpdateRuleFactory
    {
        public IUpdateRule Create(IItem item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieUpdateRule();
                case "Christmas Crackers":
                    return new ChristmasCrackerUpdateRule();
                case "Soap":
                    return new SoapUpdateRule();
                case "Fresh Item":
                    return new FreshItemUpdateRule();
                case "Frozen Item":
                    return new FrozenItemUpdateRule();
                default:
                    throw new ArgumentOutOfRangeException("NO SUCH ITEM");
            }
        }
    }
}
