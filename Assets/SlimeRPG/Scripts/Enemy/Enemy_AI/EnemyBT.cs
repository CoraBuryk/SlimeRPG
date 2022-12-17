using Assets.Scripts.Behavior_Tree;
using System.Collections.Generic;

namespace Assets.SlimeRPG.Scripts.Enemy.Enemy_AI
{
    public class EnemyBT : Tree
    {
        public UnityEngine.Transform spawnPoint;

        public static float speed = 1f;
        public static float fovRange = 3f;
        public static float attackRange = 1f;

        protected override Node SetupTree()
        {
            Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckPlayerInAttackRange(transform),
                new EnemyTaskAttack(transform),
            }),

            new Sequence(new List<Node>
            {
                new CheckPlayerInFOVRange(transform),
                new EnemyTaskGoToTarget(transform),
            }),

            new EnemyTaskWaiting(transform, spawnPoint),
        });

            return root;
        }

    }
}
