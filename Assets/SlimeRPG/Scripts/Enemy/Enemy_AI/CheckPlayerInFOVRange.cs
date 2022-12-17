using UnityEngine;
using Assets.Scripts.Behavior_Tree;

namespace Assets.SlimeRPG.Scripts.Enemy.Enemy_AI
{
    public class CheckPlayerInFOVRange : Node
    {
        private static int _playerLayerMask = 1 << 6;

        private Transform _transform;
        private Animator _animator;

        public CheckPlayerInFOVRange(Transform transform)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
        }

        public override NodeState Evaluate()
        {
            object t = GetData("target");
            if (t == null)
            {
                Collider[] colliders = Physics.OverlapSphere(
                    _transform.position, EnemyBT.fovRange, _playerLayerMask);

                if (colliders.Length > 0)
                {
                    parent.parent.SetData("target", colliders[0].transform);
                    _animator.SetBool("Walking", true);
                    state = NodeState.SUCCESS;
                    return state;
                }

                state = NodeState.FAILURE;
                return state;
            }

            state = NodeState.SUCCESS;
            return state;
        }

    }
}
