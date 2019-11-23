using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Rules
{
    public class AgedBrieUpdateRule : BaseRule, IUpdateRule
    {
        private int QualityIncrease = 1;
        public void Update(Item item)
        {
            DecreaseSellIn(item);
            if (item.Quality < MaxQuality) IncreaseQuality(QualityIncrease,item);
        }
    }
}
