﻿using Assets.Scripts.Behavior_Tree;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enemy.Enemy_AI
{
    public class CheckPlayerInAttackRange : Node
    {
        private Transform _transform;
        private Animator _animator;

        public CheckPlayerInAttackRange(Transform transform)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
        }

        public override NodeState Evaluate()
        {
            object t = GetData("target");
            if (t == null)
            {
                state = NodeState.FAILURE;
                return state;
            }

            Transform target = (Transform)t;

            if (Vector3.Distance(_transform.position, target.position) <= EnemyBT.attackRange)
            {
                _animator.SetBool("Attacking", true);
                _animator.SetBool("Walking", false);

                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}
