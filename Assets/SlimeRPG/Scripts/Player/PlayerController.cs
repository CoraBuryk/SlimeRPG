using Assets.SlimeRPG.Scripts.General;
using Assets.SlimeRPG.Scripts.UI;
using Assets.SlimeRPG.Scripts.UI.UpgradebleItems;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private RectTransform _panel;
        [SerializeField] private DamageUpgrade _damageUpgrade;
        [SerializeField] private SpeedUpgrade _speedUpgrade;
        [SerializeField] private HealthUpdate _healthUpdate;
        [SerializeField] private LevelProgress _levelProgress;
        [SerializeField] private PlayerMoneyController _playerMoneyController;
        [SerializeField] private GameObject _respawnText;

        private const int startHP = 100;
        private const int startATK = 10;
        private const float startASPD = 2f;

        public float PlayerHP { get; set; } = startHP;

        public float PlayerATK { get; set; } = startATK;

        public float PlayerASPD { get; set; } = startASPD;

        public int EnemyDefeted { get; set; }


        private int _currentLevel;
        private Sequence _textSequence;

        private void Awake()
        {
            _healthController.UpdateHeal(PlayerHP);
            _healthBar.FollowingHealthBar(transform.parent, _panel);
        }

        private void OnEnable()
        {
            _damageUpgrade.OnDamageChange += DealDamage;
            _speedUpgrade.OnSpeedChange += ShotSpeed;
            _healthUpdate.OnHealthUpgrade += Health;
            _levelProgress.OnLevelChange += LevelUp;
            _healthController.OnDeath += Respawn;
        }

        private void DealDamage(float damage)
        {
            PlayerATK = damage;
        }

        private void ShotSpeed(float speed)
        {
            PlayerASPD = speed;
        }

        private void Health(float health)
        {
            PlayerHP = health;
            _healthController.UpdateHeal(PlayerHP);
        }

        private void LevelUp()
        {
            if (EnemyDefeted > 0)
            {
                _currentLevel = _levelProgress.Level;
            }
        }

        public void Rewards()
        {
            EnemyDefeted += 1;

            int payment = _levelProgress.Level * 10;
            _playerMoneyController.AddMoney(_playerMoneyController.MoneyAmount + payment);

            if (EnemyDefeted > 1)
                _levelProgress.UpdateLevel();

            _healthController.TakeHeal(PlayerHP);
        }

        public void Respawn()
        {
            Health(startHP);
            DealDamage(startATK);
            ShotSpeed(startASPD);
            EnemyDefeted = 0;
            _currentLevel = 1;
            _respawnText.SetActive(true);
            EnableTextSequence();
        }

        private void EnableTextSequence()
        {
            _textSequence = DOTween.Sequence();
            _textSequence.Append(_respawnText.transform.DOScale(transform.localScale.magnitude, 0.2f));
            _textSequence.Append(_respawnText.transform.DOBlendableMoveBy(Vector3.up * 2f, 1f));
            _textSequence.Insert(0.2f, _respawnText.GetComponent<TMP_Text>().DOFade(0, 1f))
                .OnComplete(() => _respawnText.SetActive(false));
        }

        private void OnDisable()
        {
            _damageUpgrade.OnDamageChange -= DealDamage;
            _speedUpgrade.OnSpeedChange -= ShotSpeed;
            _healthUpdate.OnHealthUpgrade -= Health;
            _levelProgress.OnLevelChange -= LevelUp;
            _healthController.OnDeath -= Respawn;
        }
    }
}
