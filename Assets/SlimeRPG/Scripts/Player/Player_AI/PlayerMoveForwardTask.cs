using Assets.Scripts.Behavior_Tree;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Player.Player_AI
{
    public class PlayerMoveForwardTask :Node
    {
        private PlayerController _playerController;

        public PlayerMoveForwardTask(Transform transform)
        {
            _playerController = transform.GetComponent<PlayerController>();
        }

        public override NodeState Evaluate()
        {
            _playerController.PlayerMoving(PlayerBT.speed);
            state = NodeState.RUNNING;
            return state;
        }
    }
}
