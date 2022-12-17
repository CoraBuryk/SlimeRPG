using System;

namespace Assets.SlimeRPG.Scripts.UI.UpgradebleItems
{
    public class DamageUpgrade : Items
    {
        private const int _multiplier = 2;
        private int _damagePower;

        public event Action<float> OnDamageChange;

        private void Awake()
        {
            UpgradeInfo();
            MaxLevel = 100;
        }

        public void UpgradeInfo()
        {
            ItemName.text = PurchaseItem.ATK.ToString() + " Lv " + Level;
        }

        public void UpgradeDamage()
        {
            Level += 1;
            _damagePower = Level * 10;
            OnDamageChange?.Invoke(_damagePower);
        }

        public int UpgradeCost()
        {
            Cost = Level * _multiplier * 10;
            return Cost;
        }
    }
}
