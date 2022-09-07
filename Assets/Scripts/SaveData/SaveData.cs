using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Save
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData Instance;

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

        Dictionary<int, bool> savedThemeProgression = new();
        int playerCurrentCoin;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

    public struct ThemeProgression
    {
        int themeID;
        bool themeUnlocState;

        public ThemeProgression(int themeID, bool themeUnlocState)
        {
            this.themeID = themeID;
            this.themeUnlocState = themeUnlocState;
        }
    }

    public struct PlayerCoin
    {
        public int currentAmount;

        public PlayerCoin(int currentAmount)
        {
            this.currentAmount = currentAmount;
        }
    }
}