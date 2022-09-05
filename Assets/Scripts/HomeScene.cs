using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPicture.ModuleHomeScene
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _themeButton;
        private UnityAction actionChangeSceneToGameplay;
        private UnityAction actionChangeSceneToTheme;

        // Start is called before the first frame update
        void Start()
        {
            actionChangeSceneToGameplay += ChangeSceneToGameplay;
            actionChangeSceneToTheme += ChangeSceneToTheme;

            SetButtonListener(_playButton, actionChangeSceneToGameplay);
            SetButtonListener(_themeButton, actionChangeSceneToTheme);
        }

        private void SetButtonListener(Button button, UnityAction unityAction)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(unityAction);
        }

        private void ChangeSceneToGameplay()
        {
            SceneManager.LoadScene("Gameplay");
        }

        private void ChangeSceneToTheme()
        {
            SceneManager.LoadScene("Theme");
        }
    }
}