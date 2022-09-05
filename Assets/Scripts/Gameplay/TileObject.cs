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
        private TileGroup _tileGroup;
        private SpriteRenderer _spriteRenderer;

        void Start()
        {
            _isRaycasted = false;
            _defaultSprite = GetComponent<SpriteRenderer>().sprite;
            _tileGroup = transform.parent.GetComponent<TileGroup>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void OnRaycasted()
        {
            if (_isRaycasted == false)
            {
                _spriteRenderer.sprite = _tileGroup.ChangeSprite(gameObject);
                _isRaycasted = true;
            }
        }
        
        public void SetDefaultSprite()
        {
            _spriteRenderer.sprite = _defaultSprite;
        }

        public void SetIsRaycastedFasle()
        {
            _isRaycasted = false;
        }
    }
}