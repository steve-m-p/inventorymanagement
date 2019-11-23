using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Rules
{
    public class FreshItemUpdateRule : FrozenItemUpdateRule, IUpdateRule
    {
        public new void Update(IItem item)
        {
            QualityDecrement = base.QualityDecrement * 2;
            base.Update(item);
        }
    }
}
