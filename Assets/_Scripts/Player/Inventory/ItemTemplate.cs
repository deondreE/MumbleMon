using UnityEngine;

namespace _Scripts.Player.Inventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 0)]
    public class ItemTemplate : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public Texture2D itemImage;
        public GameObject itemPrefab;
    }
}