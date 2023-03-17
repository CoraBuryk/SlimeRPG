using Assets.Scripts.Behavior_Tree;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Player.Player_AI
{
    public class CheckEnemyInFOVRange : Node
    {
        private static int _enemyLayerMask = 1 << 7;

        private Transform _transform;
        private Animator _animator;
        private PlayerController _playerController;

        public CheckEnemyInFOVRange(Transform transform)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
            _playerController = transform.GetComponent<PlayerController>();
        }

        public override NodeState Evaluate()
        {
            object t = GetData("enemy");
            if (t == null)
            {
                Collider[] colliders = Physics.OverlapSphere(
                    _transform.position, PlayerBT.fovRange, _enemyLayerMask);

                if (colliders.Length > 0)
                {
                    parent.parent.SetData("enemy", colliders[0].transform);

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
