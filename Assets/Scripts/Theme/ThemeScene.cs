using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPicture.Theme
{
    public class ThemeScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        private UnityAction actionChangeSceneToHome;

        // Start is called before the first frame update
        void Start()
        {
            actionChangeSceneToHome += ChangeSceneToHome;
            _backButton.onClick.AddListener(actionChangeSceneToHome);
        }

        private void ChangeSceneToHome()
        {
            SceneManager.LoadScene("Home");
        }
    }
}