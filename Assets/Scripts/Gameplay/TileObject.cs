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
        private TileGroup tileGroup;

        void Start()
        {
            _isRaycasted = false;
            _defaultSprite = GetComponent<SpriteRenderer>().sprite;
            tileGroup = transform.parent.GetComponent<TileGroup>();
        }

        public void OnRaycasted()
        {
            if (_isRaycasted == false)
            {
                GetComponent<SpriteRenderer>().sprite = tileGroup.ChangeSprite(gameObject);
                _isRaycasted = true;
            }
        }
        
        public void SetDefaultSprite()
        {
            GetComponent<SpriteRenderer>().sprite = _defaultSprite;
        }

        public void SetIsRaycastedFasle()
        {
            _isRaycasted = false;
        }
    }
}