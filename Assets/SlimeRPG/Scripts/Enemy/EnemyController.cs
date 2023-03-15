using Assets.SlimeRPG.Scripts.General;
using Assets.SlimeRPG.Scripts.UI;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private RectTransform _panel;

        public GameObject _levelProgress; 
        public float _startHP = 40;

        private void Awake()
        {
            _levelProgress = GameObject.FindGameObjectWithTag("Level");          
        }

        private void Start()
        {
            _healthController.UpdateHeal(_startHP * _levelProgress.GetComponent<LevelProgress>().Level);
            _healthBar.FollowingHealthBar(transform, _panel);
        }

        public void DeathAnimation()
        {
            Destroy(gameObject, 1.5f);
            gameObject.SetActive(false);      
        }
    }
}
