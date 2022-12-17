using Assets.SlimeRPG.Scripts.General;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerBullet _bullet;
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private PlayerController _controller;

        public void CreateBullet(Transform target, HealthController health)
        {
            PlayerBullet newBullet = Instantiate(_bullet, _spawnTransform.position, Quaternion.identity);
            newBullet.Shot(target,_controller.PlayerASPD, health, (int)_controller.PlayerATK);
        }
    }
}
