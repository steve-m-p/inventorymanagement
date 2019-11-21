using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface IInventoryManagementService
    {
        IItem Update(IItem item);
    }
}