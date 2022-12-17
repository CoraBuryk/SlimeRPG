using Assets.SlimeRPG.Scripts.General;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _bulletRB;
        private HealthController _healthController;
        private int _damage;

        public void Shot(Transform target, float bulletSpeed, HealthController health, int damage)
        {
            Vector3 moveDir = (target.transform.position - transform.position).normalized * bulletSpeed;
            _bulletRB.velocity = new Vector3(moveDir.x, moveDir.y, moveDir.z);
            _healthController = health;
            _damage = damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            _healthController.DamageTaken(_damage);
            Destroy(gameObject);
        }
    }
}