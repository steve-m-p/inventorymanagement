﻿namespace InventoryManagement.Models
{
    public interface IItem
    {
        string Name { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }
    }
}