using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.General
{
    public class LevelController : MonoBehaviour
    {
        private int _level = 1;
        private const int _damageBuff = 10;
        public int generalDamage;

        private void Start()
        {
            Level();
        }

        public void Level()
        {
            if (_level == 1)
            {
                generalDamage = _damageBuff;
            }
        }

    }
}
