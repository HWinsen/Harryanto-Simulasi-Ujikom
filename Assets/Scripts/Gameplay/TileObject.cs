using MatchPicture.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Tile
{
    public class TileObject : MonoBehaviour, IRaycastable
    {
        [SerializeField] private bool _isRaycasted;

        // Start is called before the first frame update
        void Start()
        {
            _isRaycasted = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnRaycasted()
        {
            if (_isRaycasted)
            {
                _isRaycasted = false;
                Debug.Log(gameObject.name + " raycasted: " + _isRaycasted);
            }
            else
            {
                _isRaycasted = true;
                Debug.Log(gameObject.name + " raycasted: " + _isRaycasted);
            }
        }
    }
}