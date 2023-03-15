using Assets.SlimeRPG.Scripts.General;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerBullet _bullet;
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private PlayerController _controller;

        private List<PlayerBullet> _pooledBullet = new List<PlayerBullet>();
        private int _amountToPool = 10;

        private void Start()
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                PlayerBullet newBullet = Instantiate(_bullet, _spawnTransform.position, Quaternion.identity);
                newBullet.transform.parent = _spawnTransform;
                newBullet.gameObject.SetActive(false);
                _pooledBullet.Add(newBullet);
            }
        }

        private PlayerBullet GetPooledBullet()
        {
            for (int i = 0; i < _pooledBullet.Count; i++)
            {
                if (!_pooledBullet[i].gameObject.activeInHierarchy)
                {
                    return _pooledBullet[i];
                }
            }
            return null;
        }

        public void CreateBullet(Transform target, HealthController health)
        {
            PlayerBullet bullet = GetPooledBullet();

            if (bullet != null)
            {
                bullet.gameObject.transform.position = _spawnTransform.position;
                bullet.gameObject.transform.rotation = _spawnTransform.rotation;
                bullet.gameObject.SetActive(true);
                bullet.Shot(target, _controller.PlayerASPD, health, (int)_controller.PlayerATK);
            }

        }
    } 
}
