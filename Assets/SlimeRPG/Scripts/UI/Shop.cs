using Assets.SlimeRPG.Scripts.Player;
using Assets.SlimeRPG.Scripts.UI.UpgradebleItems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SlimeRPG.Scripts.UI
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private DamageUpgrade _damageUpgrade;
        [SerializeField] private SpeedUpgrade _speedUpgrade;
        [SerializeField] private HealthUpdate _healthUpdate;

        [SerializeField] private Button _damageUpgradeButton;
        [SerializeField] private Button _speedUpgradeButton;
        [SerializeField] private Button _healthUpgradeButton;

        [SerializeField] private TMP_Text _damageUpgradeCost;
        [SerializeField] private TMP_Text _speedUpgradeCost;
        [SerializeField] private TMP_Text _healthUpgradeCost;

        [SerializeField] private PlayerMoneyController _moneyController;

        private void OnEnable()
        {
            _damageUpgradeButton.onClick.AddListener(UpgradeDamageInfo);
            _speedUpgradeButton.onClick.AddListener(UpgradeSpeedInfo);
            _healthUpgradeButton.onClick.AddListener(UpgradeHealthInfo);
            _moneyController.OnMoneyChanged += CheckEnoughMoneyForDamage;
            _moneyController.OnMoneyChanged += CheckEnoughMoneyForSpeed;
            _moneyController.OnMoneyChanged += CheckEnoughMoneyForHealth;
        }

        private void Awake()
        {
            _damageUpgradeCost.text = _damageUpgrade.Cost.ToString();
            _speedUpgradeCost.text = _speedUpgrade.Cost.ToString();
            _healthUpgradeCost.text = _healthUpdate.Cost.ToString();
        }

        private void UpgradeDamageInfo()
        {
            _moneyController.RemoveMoney(_damageUpgrade.Cost);
            _damageUpgrade.UpgradeDamage();
            _damageUpgrade.UpgradeInfo();
            _damageUpgradeCost.text = _damageUpgrade.UpgradeCost().ToString();
            CheckEnoughMoneyForDamage();
            CheckMaxLevelForDamage();
        }

        private void CheckEnoughMoneyForDamage()
        {
            if (_moneyController.MoneyAmount < _damageUpgrade.Cost)
                _damageUpgradeButton.interactable = false;
            else
                _damageUpgradeButton.interactable = true;
        }

        private void CheckMaxLevelForDamage()
        {
            if (_damageUpgrade.Level == _damageUpgrade.MaxLevel)
            {
                _damageUpgradeButton.interactable = false;
                _damageUpgradeCost.text = "MAX LV";
            }
        }

        private void UpgradeSpeedInfo()
        {
            _moneyController.RemoveMoney(_speedUpgrade.Cost);
            _speedUpgrade.UpgradeSpeed();
            _speedUpgrade.UpgradeInfo();
            _speedUpgradeCost.text = _speedUpgrade.UpgradeCost().ToString();
            CheckEnoughMoneyForSpeed();
            CheckMaxLevelForSpeed();
        }

        private void CheckEnoughMoneyForSpeed()
        {
            if (_moneyController.MoneyAmount < _speedUpgrade.Cost)
                _speedUpgradeButton.interactable = false;
            else
                _speedUpgradeButton.interactable = true;
        }

        private void CheckMaxLevelForSpeed()
        {
            if (_speedUpgrade.Level == _speedUpgrade.MaxLevel)
            {
                _speedUpgradeButton.interactable = false;
                _speedUpgradeCost.text = "MAX LV";
            }
        }

        private void UpgradeHealthInfo()
        {
            _moneyController.RemoveMoney(_healthUpdate.Cost);
            _healthUpdate.UpgradeHealth();
            _healthUpdate.UpgradeInfo();
            _healthUpgradeCost.text = _healthUpdate.UpgradeCost().ToString();
            CheckEnoughMoneyForHealth();
            CheckMaxLevelForHealth();
        }

        private void CheckEnoughMoneyForHealth()
        {
            if(_moneyController.MoneyAmount < _healthUpdate.Cost)          
                _healthUpgradeButton.interactable = false;         
            else
                _healthUpgradeButton.interactable = true;
        }

        private void CheckMaxLevelForHealth()
        {
            if (_healthUpdate.Level == _healthUpdate.MaxLevel)
            {
                _healthUpgradeButton.interactable = false;
                _healthUpgradeCost.text = "MAX LV";
            }
        }

        private void OnDisable()
        {
            _damageUpgradeButton.onClick.RemoveListener(UpgradeDamageInfo);
            _speedUpgradeButton.onClick.RemoveListener(UpgradeSpeedInfo);
            _healthUpgradeButton.onClick.RemoveListener(UpgradeHealthInfo);
            _moneyController.OnMoneyChanged -= CheckEnoughMoneyForDamage;
            _moneyController.OnMoneyChanged -= CheckEnoughMoneyForSpeed;
            _moneyController.OnMoneyChanged -= CheckEnoughMoneyForHealth;
        }
    }
}
