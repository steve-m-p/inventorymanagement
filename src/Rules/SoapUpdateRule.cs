using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Rules
{
    public class SoapUpdateRule : IUpdateRule
    {
        public void Update(IItem item)
        {
            item.SellIn = item.SellIn;
            item.Quality = item.Quality;
        }
    }
}
