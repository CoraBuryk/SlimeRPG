using System;

namespace Assets.SlimeRPG.Scripts.UI.UpgradebleItems
{
    public class HealthUpdate: Items
    {
        private const int _increase = 100;
        private int _hp;

        public event Action<float> OnHealthUpgrade;

        private void Awake()
        {
            UpgradeInfo();
            MaxLevel = 100;
        }

        public void UpgradeInfo()
        {
            ItemName.text = PurchaseItem.HP.ToString() + " Lv " + Level;
        }

        public void UpgradeHealth()
        {
            Level += 1;
            _hp += _increase;
            OnHealthUpgrade?.Invoke(_hp);
        }

        public int UpgradeCost()
        {
            Cost = (int)(Level * 10);
            return Cost;
        }
    }
}
