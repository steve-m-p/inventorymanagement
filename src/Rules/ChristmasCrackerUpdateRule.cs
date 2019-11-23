using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Rules
{
    public class ChristmasCrackerUpdateRule: BaseRule, IUpdateRule
    {
        public void Update(IItem item)
        {
            DecreaseSellIn(item);
            var qualityIncrease = 0;
            if (item.SellIn < 10) qualityIncrease = 2;
            if (item.SellIn < 5) qualityIncrease = 3;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else
            {
                IncreaseQuality(qualityIncrease, item);
            }

        }
    }
}
