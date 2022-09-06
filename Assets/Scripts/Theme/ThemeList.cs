using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace MatchPicture.Theme
{
    [System.Serializable]
    public class Theme
    {
        public string themeName;
        public SpriteAtlas themeSpriteAtlas;
    }

    public class ThemeList : MonoBehaviour
    {
        [SerializeField] private Theme[] _themes;
        [SerializeField] private Button _themeButton;
        [SerializeField] private GameObject _confirmationPopup;
        [SerializeField] private TMP_Text _title;
        public bool isUnlocked { private set; get; }

        // Start is called before the first frame update
        void Start()
        {
            foreach (Theme theme in _themes)
            {
                var tempGO = Instantiate(_themeButton, transform.position, Quaternion.identity);
                tempGO.name = theme.themeName;
                tempGO.onClick.RemoveAllListeners();
                tempGO.onClick.AddListener(() =>
                {
                    if (isUnlocked)
                    {
                        ChangeTheme();
                    }
                    else
                    {
                        UnlockTheme();
                    }
                });
                tempGO.transform.parent = gameObject.transform;
            }
        }

        void UnlockTheme()
        {
            Debug.Log("unlock theme");
        }

        void ChangeTheme()
        {
            Debug.Log("change theme");
        }
    }
}