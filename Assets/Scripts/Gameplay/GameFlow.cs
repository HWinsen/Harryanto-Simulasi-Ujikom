using Agate.MVC.Core;
using MatchPicture.PubSub;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Gameplay
{
    public class GameFlow : MonoBehaviour
    {
        void Start()
        {
            PublishSubscribe.Instance.Subscribe<MessageGameOver>(SetGameOverState);
        }

        void OnDestroy()
        {
            PublishSubscribe.Instance.Unsubscribe<MessageGameOver>(SetGameOverState);
        }

        private void SetGameOverState(MessageGameOver message)
        {
            Debug.Log("game over");
        }
    }
}