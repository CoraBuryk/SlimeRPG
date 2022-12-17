using Assets.Scripts.Behavior_Tree;
using Assets.SlimeRPG.Scripts.Enemy;
using Assets.SlimeRPG.Scripts.General;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Player.Player_AI
{
    public class PlayerTaskAttack : Node
    {
        private Animator _animator;

        private Transform _lastTarget;
        private PlayerAttack _playerAttack;
        private HealthController _healthController;
        private PlayerController _playerController;
        private EnemyController _enemyController;
        private ColorChange _colorChange;

        private float _attackTime = 1f;
        private float _attackCounter = 0f;


        public PlayerTaskAttack(Transform transform)
        {
            _animator = transform.GetComponent<Animator>();
            _playerAttack = transform.GetComponent<PlayerAttack>();
            _playerController = transform.GetComponent<PlayerController>();
        }

        public override NodeState Evaluate()
        {
            Transform target = (Transform)GetData("enemy");
            if (target != _lastTarget)
            {
                _healthController = target.GetComponent<HealthController>();
                _enemyController = target.GetComponent<EnemyController>();
                _colorChange = target.GetComponent<ColorChange>();
                _lastTarget = target;
            }

            _attackCounter += Time.deltaTime;

            if (_attackCounter >= _attackTime)
            {
                if (_healthController.IsDead)
                {
                    ClearData("enemy");

                    _playerController.Rewards();

                    _animator.SetBool("Attacking", false);
                    _animator.SetBool("Walking", true);

                    _enemyController.DeathAnimation();
                }
                else
                {
                    _attackCounter = 0f;
                    _playerAttack.CreateBullet(target, _healthController);

                    _colorChange.DoHitFlash();
                }
            }

            state = NodeState.RUNNING;
            return state;
        }
    }
}
