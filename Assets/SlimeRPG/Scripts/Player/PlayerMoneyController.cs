using System;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Player
{
    public class PlayerMoneyController : MonoBehaviour
    {
        public event Action OnMoneyChanged;

        [SerializeField] private int _moneyAmount;

        public int MoneyAmount { get { return _moneyAmount; } set { } }

        public void AddMoney(int amount)
        {
            _moneyAmount = amount;
            OnMoneyChanged?.Invoke();
        }

        public void RemoveMoney(int amount)
        {
            if (_moneyAmount - amount >= 0)
                _moneyAmount -= amount;
            OnMoneyChanged?.Invoke();
        }
    }
}