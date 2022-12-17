using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _enemySpawnPoints;
        [SerializeField] private GameObject _enemyPref;

        private void Start()
        {
            InvokeRepeating("SpawnEnemy", 5f, 13f);
        }

        private void SpawnEnemy()
        {
            Instantiate(_enemyPref, _enemySpawnPoints.position, Quaternion.identity);
        }
    }
}
