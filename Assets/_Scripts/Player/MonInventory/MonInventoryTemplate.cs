using _Scripts.Mons;
using UnityEngine;

namespace _Scripts.Player.MonInventory
{
    [CreateAssetMenu(fileName = "New MonInventory", menuName = "Inventory/MonInventory", order = 0)]
    public class MonInventoryTemplate : ScriptableObject
    {
        public string inventoryName;
        public int pageNumber;
        public MonTemplate[] mons;
    }
}