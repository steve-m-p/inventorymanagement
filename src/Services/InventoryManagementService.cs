using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;
using InventoryManagement.Rules;

namespace InventoryManagement.Services
{
    public class InventoryManagementService : IInventoryManagementService
    {
        private readonly Func<ItemType, IUpdateRule> _updateRule;

        public InventoryManagementService(Func<ItemType, IUpdateRule> updateRule)
        {
            _updateRule = updateRule;
        }

        public IEnumerable<string> Update(IEnumerable<Item> items)
        {
            var output = new List<string>();
            foreach (var item in items)
            {
                var transformedName = item.Name.Replace(" ", string.Empty);
                if (Enum.TryParse(transformedName, true, out ItemType itemType))
                {
                    _updateRule(itemType).Update(item);
                    output.Add(item.ToString());
                }
                else
                {
                    output.Add("NO SUCH ITEM");
                }
            }
            return output;
        }
    }
}