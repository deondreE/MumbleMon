using System;
using UnityEngine;

namespace _Scripts.Mons.Spawning
{
    public class MonPlayer : MonoBehaviour
    {
        #region Singleton

        public static MonPlayer instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion
        
        [Header("Radius Sizes")]
        [SerializeField] public float battleRadius;
        [SerializeField] public float spawnRadius;

        [Header("Radius Colors")] 
        [SerializeField] private Color battleRadiusColor = Color.red;
        [SerializeField] private Color spawnRadiusColor;

        private void OnDrawGizmosSelected()
        {
            // Radius in which mon will fight a player.
            Gizmos.color = battleRadiusColor;
            Gizmos.DrawWireSphere(transform.position, battleRadius);

            // Radius in which mon will spawn around player.
            Gizmos.color = spawnRadiusColor;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}