using Agate.MVC.Core;
using MatchPicture.PubSub;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MatchPicture.Gameplay
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private float gameDuration;
        [SerializeField] private TMP_Text timerText;

        // Start is called before the first frame update
        void Start()
        {
            timerText = GetComponent<TMP_Text>();

            if (gameDuration <= 0)
            {
                gameDuration = 300f;
            }
        }

        // Update is called once per frame
        void Update()
        {
            timerText.SetText(gameDuration.ToString("F0"));
            if (gameDuration > 0)
            {
                gameDuration -= Time.deltaTime;
            }
            else if (gameDuration == 0)
            {
                PublishSubscribe.Instance.Publish<TimeOver>(new TimeOver());
                this.enabled = false;
            }
        }
    }
}