﻿using Assets.Scripts.Behavior_Tree;
using Assets.SlimeRPG.Scripts.General;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.Enemy.Enemy_AI
{
    public class EnemyTaskAttack : Node
    {
        private Animator _animator;

        private Transform _lastTarget;
        private HealthController _playerHealthController;
        private LevelController _levelController;
        private ColorChange _colorChange;

        private float _attackTime = 1.2f;
        private float _attackCounter = 0f;

        public EnemyTaskAttack(Transform transform)
        {
            _animator = transform.GetComponent<Animator>();
            _animator.fireEvents = false;
            _levelController = transform.GetComponent<LevelController>();
        }

        public override NodeState Evaluate()
        {
            Transform target = (Transform)GetData("target");
            if (target != _lastTarget)
            {
                _playerHealthController = target.GetComponent<HealthController>();
                _colorChange = target.GetComponent<ColorChange>();
                _lastTarget = target;
            }
            _attackCounter += Time.deltaTime;

            if (_attackCounter >= _attackTime)
            {
                if (_playerHealthController.IsDead)
                {
                    ClearData("target");
                    _animator.SetBool("Attacking", false);
                    _animator.SetBool("Idle", true);
                }
                else
                {
                    _attackCounter = 0f;
                    _colorChange.DoHitFlash();
                    _playerHealthController.DamageTaken(_levelController.generalDamage);
                }
            }

            state = NodeState.RUNNING;
            return state;
        }
    }
}