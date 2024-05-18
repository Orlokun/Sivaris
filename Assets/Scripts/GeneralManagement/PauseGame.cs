using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeneralManagement
{
    public class PauseGame : MonoBehaviour
    {
        private bool isPausedGame = false;
        [SerializeField] private GameObject PauseMenu;

        [SerializeField] private Button QuitGameButton;
        [SerializeField] private Button ContinueButton;

        private void Awake()
        {
            QuitGameButton.onClick.AddListener(CloseGame);
            QuitGameButton.onClick.AddListener(TogglePauseSystem);
            PauseMenu.SetActive(false);
        }

        private void CloseGame()
        {
            Application.Quit();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseSystem();
            }
        }

        private void TogglePauseSystem()
        {
            isPausedGame = !isPausedGame;
            Time.timeScale = isPausedGame ? 0 : 1;
            PauseMenu.SetActive(isPausedGame);
        }
    }
}