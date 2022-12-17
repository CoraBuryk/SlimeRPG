using System;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.UI
{
    public class LevelProgress : MonoBehaviour
    {
        public int Level { get; set; } = 1;

        public event Action OnLevelChange;

        public void UpdateLevel()
        {
            Level++;
            OnLevelChange?.Invoke();
        }

    }
}
