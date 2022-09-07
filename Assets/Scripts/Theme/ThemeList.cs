using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPicture.Theme
{
    public class ThemeList : MonoBehaviour
    {
        [SerializeField] private Button _themeButton;

        // Start is called before the first frame update
        void Start()
        {
            foreach (Theme theme in ThemeDatabase.Instance.themes)
            {
                var tempButton = Instantiate(_themeButton, transform.position, Quaternion.identity);
                tempButton.name = theme.themeName;
                TMP_Text buttonText = tempButton.GetComponentInChildren<TMP_Text>();
                if (theme.isUnlocked)
                {
                    buttonText.SetText($"{tempButton.name}");
                }
                else
                {
                    buttonText.SetText($"Buy {tempButton.name} {theme.price}g");
                }
                tempButton.onClick.RemoveAllListeners();
                tempButton.onClick.AddListener(() =>
                {
                    if (theme.isUnlocked)
                    {
                        ChangeTheme(tempButton.name);
                    }
                    else
                    {
                        UnlockTheme(tempButton.name, buttonText);
                    }
                });
                tempButton.transform.SetParent(gameObject.transform);
            }
        }

        void UnlockTheme(string themeName, TMP_Text text)
        {
            Debug.Log("unlock theme " + themeName);

            ThemeDatabase.Instance.SetThemeUnlock(themeName);
            Debug.Log("Kurangin duit");
            text.SetText($"{themeName}");
            // ChangeTheme(themeName);
        }

        void ChangeTheme(string themeName)
        {
            Debug.Log("change theme to " +themeName);
            ThemeDatabase.Instance.SetUsedTheme(themeName);
            SceneManager.LoadScene("Gameplay");
        }
    }
}