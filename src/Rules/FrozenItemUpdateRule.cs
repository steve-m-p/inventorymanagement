using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace InventoryManagement.Rules
{
    public class FrozenItemUpdateRule : BaseRule, IUpdateRule
    {
        public int QualityDecrement = 1;

        public void Update(Item item)
        {
            DecreaseSellIn(item);
            if (item.Quality > MaxQuality)
            {
                item.Quality = MaxQuality;
                return;
            }

            if (item.Quality <= MinQuality) return;
            if (item.SellIn < 0)
            {
                QualityDecrement = QualityDecrement * 2;
            }
            DecreaseQuality(QualityDecrement, item);


        }
    }
}