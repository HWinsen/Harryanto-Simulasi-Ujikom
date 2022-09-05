using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPicture.Gameplay
{
    public class GameplayScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        private UnityAction actionChangeSceneToHome;

        // Start is called before the first frame update
        void Start()
        {
            actionChangeSceneToHome += ChangeSceneToHome;
            SetButtonListener(_backButton, actionChangeSceneToHome);
        }

        private void SetButtonListener(Button button, UnityAction unityAction)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(unityAction);
        }

        private void ChangeSceneToHome()
        {
            SceneManager.LoadScene("Home");
        }
    }
}