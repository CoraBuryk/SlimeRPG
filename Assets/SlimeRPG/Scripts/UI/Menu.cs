using UnityEngine;
using UnityEngine.UI;

namespace Assets.SlimeRPG.Scripts.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _exit;

        private void OnEnable()
        {
            _exit.onClick.AddListener(QuitGame);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        private void OnDisable()
        {
            _exit.onClick.RemoveListener(QuitGame);
        }
    }
}
