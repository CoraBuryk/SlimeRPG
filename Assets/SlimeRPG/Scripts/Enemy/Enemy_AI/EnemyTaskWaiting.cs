using Assets.Scripts.Behavior_Tree;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enemy.Enemy_AI
{
    public class EnemyTaskWaiting : Node
    {
        private Transform _transform;
        private Animator _animator;
        private Transform _spawnPoint;

        public EnemyTaskWaiting(Transform transform, Transform spawnPoint)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
            _spawnPoint = spawnPoint;
        }

        public override NodeState Evaluate()
        {
            _animator.SetBool("Walking", true);
            _animator.SetBool("Idle", false);
            _transform.position = Vector3.MoveTowards(_transform.position, _spawnPoint.position, EnemyBT.speed * Time.deltaTime);
            _transform.LookAt(_spawnPoint.position);

            if (Vector3.Distance(_transform.position, _spawnPoint.position) < 0.01f)
            {
                _animator.SetBool("Idle", true);
                _animator.SetBool("Walking", false);
            }

            state = NodeState.RUNNING;
            return state;
        }
    }
}
