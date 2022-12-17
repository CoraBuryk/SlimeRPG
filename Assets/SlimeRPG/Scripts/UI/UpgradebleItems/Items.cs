using UnityEngine;

namespace Assets.SlimeRPG.Scripts.UI.UpgradebleItems
{
    public abstract class Items : MonoBehaviour
    {
        public TMPro.TMP_Text ItemName;
        public int Level = 1;
        public int Cost = 10;
        public int MaxLevel;
    }
}
