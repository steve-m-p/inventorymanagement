using InventoryManagement.Models;
using InventoryManagement.Rules;

namespace InventoryManagement.Factories
{
    public interface IUpdateRuleFactory
    {
        IUpdateRule Create(IItem item);
    }
}