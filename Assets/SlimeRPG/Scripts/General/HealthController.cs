using System;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.General
{
    public class HealthController : MonoBehaviour
    {
        private float _maxHP;
        public float _currentHealth;
        public bool IsDead { get; set; } = false;
        public bool IsHited { get; set; } = false;

        public float CurrentHealth { get { return _currentHealth; } set { } }
        public float HealthPercent => CurrentHealth / _maxHP;

        public event Action<float> OnHeal;
        public event Action<float> OnDamage;
        public event Action OnDeath;

        public void DamageTaken(int damage)
        {
            IsHited = true;
            if (IsDead == false)
            {
                _currentHealth = CurrentHealth - damage;

                if (CurrentHealth < 0)
                    _currentHealth = 0;
                CurrentState();
            }
            OnDamage?.Invoke(damage);
        }

        private void CurrentState()
        {
            if (CurrentHealth <= 0)
            {
                IsDead = true;
                OnDeath?.Invoke();
            }
        }

        public void UpdateHeal(float newHPAmount)
        {
            float hpDiff = newHPAmount - _maxHP;
            _maxHP = newHPAmount;
            TakeHeal(hpDiff);
        }

        public void TakeHeal(float _hpCount)
        {
            _currentHealth = CurrentHealth + _hpCount;
            if (CurrentHealth > _maxHP)
                _currentHealth = _maxHP;

            OnHeal?.Invoke(_currentHealth);
        }
    }
}