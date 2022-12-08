using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Managers
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private Slider healthBarUI;
        private int _currentHealth;

        private void Awake()
        {
            SetValues();
        }

        private void SetValues()
        {
            _currentHealth = maxHealth;
            healthBarUI.value = maxHealth;
            healthBarUI.maxValue = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            UpdateHealth();
        }

        public void Heal(int amount)
        {
            _currentHealth += amount;
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            healthBarUI.value = _currentHealth;
        }
    }
}