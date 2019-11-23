using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class ItemsViewModel
    {
        public List<Item> Items { get; set; }

        public ItemsViewModel()
        {
            Items = new List<Item>();
        }
    }
}