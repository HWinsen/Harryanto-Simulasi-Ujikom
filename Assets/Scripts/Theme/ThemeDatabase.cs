using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace MatchPicture.Theme
{
    [System.Serializable]
    public class Theme
    {
        public string themeName;
        public int price;
        public SpriteAtlas themeSpriteAtlas;
        public bool isUnlocked;
    }

    public class ThemeDatabase : MonoBehaviour
    {
        public static ThemeDatabase Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(base.gameObject); 
            }
            else
            {
                Destroy(base.gameObject);
            }
        }

        public Theme[] themes;
        private string usedThemeName;

        public void SetUsedTheme(string themeName)
        {
            usedThemeName = themeName;
        }

        public void SetThemeUnlock(string themeName)
        {
            foreach(Theme theme in themes)
            {
                if (theme.themeName == themeName)
                {
                    theme.isUnlocked = true;
                }
            }
        }

        public SpriteAtlas LoadTheme()
        {
            SpriteAtlas selectedAtlas = new();

            foreach(Theme theme in themes)
            {
                if (theme.themeName == usedThemeName)
                {
                    selectedAtlas = theme.themeSpriteAtlas;
                }
            }

            return selectedAtlas;
        }

    }
}