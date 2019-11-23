using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Rules
{
    public abstract class BaseRule
    {
        protected int MinQuality { get; private set; } = 0;
        protected int MaxQuality { get; private set; } = 50;
        protected void IncreaseQuality(int increment, Item item)
        {
            item.Quality += increment;
        }

        protected void DecreaseQuality(int decrement, Item item)
        {
            item.Quality -= decrement;
        }

        protected void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}