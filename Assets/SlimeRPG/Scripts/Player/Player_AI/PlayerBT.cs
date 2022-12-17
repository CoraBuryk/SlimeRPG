using Assets.Scripts.Behavior_Tree;
using System.Collections.Generic;

namespace Assets.SlimeRPG.Scripts.Player.Player_AI
{
    public class PlayerBT : Tree
    {
        public UnityEngine.Transform spawnPoint;

        public static float fovRange = 8f;
        public static float attackRange = 5f;

        protected override Node SetupTree()
        {
            Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new PlayerTaskAttack(transform),
            }),

            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
            }),
        });

            return root;
        }
    }
}
