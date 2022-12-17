using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SlimeRPG.Scripts.General
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _fullbarImage;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private TMP_Text _healthText;

        private RectTransform _panel;
        private Transform _objectToFollow;
        private float fillAmount;


        private void Awake()
        {
            _fullbarImage.fillAmount = 1;
        }

        private void OnEnable()
        {
            _healthController.OnHeal += GetCurrentHP;
            _healthController.OnDamage += GetCurrentHP;
        }

        private void GetCurrentHP(float damage)
        {
            fillAmount = _healthController.HealthPercent;
            _fullbarImage.fillAmount = fillAmount;
        }

        public void FollowingHealthBar(Transform objectTransform, RectTransform panel)
        {
            _panel = panel;
            _objectToFollow = objectTransform;
            gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _healthController.OnHeal -= GetCurrentHP;
            _healthController.OnDamage -= GetCurrentHP;
        }
    }
}
