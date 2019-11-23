using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Factories;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class InventoryManagementService : IInventoryManagementService
    {
        public IItem Update(IItem item)
        {

            var factory = new UpdateRuleFactory();

            var updateRule = factory.Create(item);

            updateRule.Update(item);

            return new Item() {Name = item.Name, SellIn = item.SellIn, Quality = item.Quality};
        }

    }
}
