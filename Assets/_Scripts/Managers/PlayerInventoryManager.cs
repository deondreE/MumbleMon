using System;
using _Scripts.Player;
using _Scripts.Player.Inventory;
using UnityEngine;

namespace _Scripts.Managers
{
    public class PlayerInventoryManager : MonoBehaviour
    {
        [SerializeField] private InventoryTemplate playerInventoryTemplate;

        [SerializeField] private GameObject inventoryUI;

        public Interaction _interaction;
        
        public void AddItem(ItemTemplate item, int amount)
        {
            playerInventoryTemplate.Container.Add(item, amount);
        }

        private void ToggleInventory()
        {
            if (_interaction.InventoryToggle())
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            }
        }

        private void UpdateInventory()
        {
            foreach (var item in playerInventoryTemplate.Container)
            {
                Instantiate(item.Key.itemPrefab, inventoryUI.transform.position, Quaternion.identity);
            }
        }

        private void Update()
        {
            ToggleInventory();
            UpdateInventory();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Item"))
            {
                Debug.Log("Entered");
                WorldItem wI = collision.gameObject.GetComponent<WorldItem>();
                AddItem(wI.worldItemTemplate, 1);
            }
        }
    }
}