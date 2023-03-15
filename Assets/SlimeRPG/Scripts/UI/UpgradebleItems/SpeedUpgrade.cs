using System;

namespace Assets.SlimeRPG.Scripts.UI.UpgradebleItems
{
    public class SpeedUpgrade : Items
    {
        private const float _multiplier = 2f;
        private int _speed;

        public event Action<float> OnSpeedChange;

        private void Awake()
        {
            UpgradeInfo();
            MaxLevel = 20;
        }

        public void UpgradeInfo()
        {
            ItemName.text = PurchaseItem.ASPD.ToString() + " Lv " + Level;
        }

        public void UpgradeSpeed()
        {
            Level += 1;
            _speed = (int)(Level * _multiplier);
            OnSpeedChange?.Invoke(_speed);
        }

        public int UpgradeCost()
        {
            Cost = (int)(Level * _multiplier * 10);
            return Cost;
        }
    }
}
