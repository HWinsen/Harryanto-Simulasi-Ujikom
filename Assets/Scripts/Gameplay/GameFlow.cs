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
            PublishSubscribe.Instance.Subscribe<TilesCleared>(SetWinState);
            PublishSubscribe.Instance.Subscribe<TimeOver>(SetGameOverState);
        }

        void OnDestroy()
        {
            PublishSubscribe.Instance.Unsubscribe<TilesCleared>(SetWinState);
            PublishSubscribe.Instance.Unsubscribe<TimeOver>(SetGameOverState);
        }

        private void SetGameOverState(TimeOver message)
        {
            Debug.Log("game over");
        }

        private void SetWinState(TilesCleared message)
        {
            Debug.Log("win");
        }
    }
}