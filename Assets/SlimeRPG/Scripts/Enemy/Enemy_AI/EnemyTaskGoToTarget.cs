using Assets.Scripts.Behavior_Tree;
using Assets.SlimeRPG.Scripts.General;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enemy.Enemy_AI
{
    public class EnemyTaskGoToTarget : Node
    {
        private Animator _animator;
        private Transform _transform;
        private HealthController _healthController;

        private float _waitTime = 0.3f;
        private float _waitCounter = 0f;

        public EnemyTaskGoToTarget(Transform transform)
        {
            _transform = transform;
            _healthController = transform.GetComponent<HealthController>();
            _animator = transform.GetComponent<Animator>();
        }

        public override NodeState Evaluate()
        {
            Transform target = (Transform)GetData("target");

            if (_healthController.IsHited == false)
            {
                if (Vector3.Distance(_transform.position, target.position) > 0.1f)
                {
                    _transform.position = Vector3.MoveTowards(
                                        _transform.position, target.position, EnemyBT.speed * Time.deltaTime);
                    _transform.LookAt(target.position);
                }
            }
            else
            {
                _animator.SetBool("Walking", false);

                _waitCounter += Time.deltaTime;

                if(_waitCounter >= _waitTime)
                {
                    _animator.SetBool("Walking", true);
                    _waitCounter = 0f;
                    _healthController.IsHited = false;
                }
            }       

            state = NodeState.RUNNING;
            return state;
        }

    }
}
