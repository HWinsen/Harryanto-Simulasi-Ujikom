using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.PubSub
{
    public class PubSubContainer { }

    // public struct MessageGameOver
    // {
    //     public string isWin;

    //     public MessageGameOver(string isWin)
    //     {
    //         this.isWin = isWin;
    //     }
    // }

    public struct TimeOver
    {

    }

    public struct TilesCleared
    {

    }

    public struct TilesClicked
    {
        public GameObject tile;

        public TilesClicked(GameObject tile)
        {
            this.tile = tile;
        }
    }
}