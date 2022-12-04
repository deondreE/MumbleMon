using System;
using UnityEngine;

namespace _Scripts.Player.Inventory
{
    public class WorldItem : MonoBehaviour
    {
        [SerializeField] public ItemTemplate worldItemTemplate;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}