using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Player.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory", order = 0)]
    public class InventoryTemplate : ScriptableObject
    {
        public string inventoryName;
        public Dictionary<ItemTemplate, int> Container = new Dictionary<ItemTemplate, int>();
    }
}