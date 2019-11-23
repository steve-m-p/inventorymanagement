using InventoryManagement.Models;

namespace InventoryManagement.Rules
{
    public interface IUpdateRule
    {
        void Update(Item item);
    }
}