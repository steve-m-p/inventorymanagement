using System.Collections.Generic;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface IInventoryManagementService
    {
        IEnumerable<string> Update(IEnumerable<Item> item);
    }
}