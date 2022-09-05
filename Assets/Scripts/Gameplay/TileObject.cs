using MatchPicture.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Tile
{
    public class TileObject : MonoBehaviour, IRaycastable
    {
        [SerializeField] private bool _isRaycasted;
        [SerializeField] private Sprite _defaultSprite;

        // Start is called before the first frame update
        void Start()
        {
            _isRaycasted = false;
            _defaultSprite = GetComponent<SpriteRenderer>().sprite;
        }

        public void OnRaycasted()
        {
            if (_isRaycasted)
            {
                SetDefaultSprite();
                _isRaycasted = false;
                Debug.Log(gameObject.name + " raycasted: " + _isRaycasted);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<TileGroup>().ChangeSprite(gameObject);
                _isRaycasted = true;
                Debug.Log(gameObject.name + " raycasted: " + _isRaycasted);
            }
        }
        
        public void SetDefaultSprite()
        {
            GetComponent<SpriteRenderer>().sprite = _defaultSprite;
        }
    }
}