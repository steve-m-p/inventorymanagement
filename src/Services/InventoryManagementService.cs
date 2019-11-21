using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class InventoryManagementService : IInventoryManagementService
    {
        public IItem Update(IItem item)
        {
            return new Item() {Name = item.Name, SellIn = item.SellIn, Quality = item.Quality};
        }

    }
}
