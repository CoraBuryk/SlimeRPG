using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _enemySpawnPoints;
        [SerializeField] private GameObject _enemyPref;

        private void Start()
        {
            InvokeRepeating(nameof(CreateEnemy), 5f, 13f);
        }

        private void CreateEnemy()
        {
            GameObject newEnemy = Instantiate(_enemyPref, _enemySpawnPoints.position, Quaternion.identity);
            newEnemy.transform.parent = _enemySpawnPoints;
        }
    }
}
