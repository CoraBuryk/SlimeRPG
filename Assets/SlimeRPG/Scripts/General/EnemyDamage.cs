using Assets.SlimeRPG.Scripts.UI;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.General
{
    public class EnemyDamage : MonoBehaviour
    {
        private const int _damageBuff = 10;
        public int GeneralDamage { get; set; } = 10;

        private GameObject _levelProgress;

        private void Awake()
        {
            _levelProgress = GameObject.FindGameObjectWithTag("Level");
        }

        private void Start()
        {
            TotalDamage();
        }

        public void TotalDamage()
        {
            GeneralDamage = _damageBuff * _levelProgress.GetComponent<LevelProgress>().Level;
        }

    }
}
