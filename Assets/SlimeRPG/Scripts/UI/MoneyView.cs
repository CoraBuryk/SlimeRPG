using Assets.SlimeRPG.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.UI
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsAmount;
        [SerializeField] private PlayerMoneyController _playerMoneyController;

        private void OnEnable()
        {
            _playerMoneyController.OnMoneyChanged += UpdateMoney;
        }

        private void Start()
        {
            UpdateMoney();
        }

        public void UpdateMoney()
        {
            _coinsAmount.text = _playerMoneyController.MoneyAmount.ToString();
        }

        private void OnDisable()
        {
            _playerMoneyController.OnMoneyChanged -= UpdateMoney;
        }
    }
}