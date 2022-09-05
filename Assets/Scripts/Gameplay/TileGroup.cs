using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace MatchPicture.Tile
{
    public class TileGroup : MonoBehaviour
    {
        [SerializeField] private int _column;
        [SerializeField] private int _row;
        [SerializeField] private GameObject _tile;
        [SerializeField] private int _themeID;
        public int[] spriteArray;
        public SpriteAtlas tileAtlas;
        private Dictionary<Vector2, GameObject> _tiles = new Dictionary<Vector2, GameObject>();
        [SerializeField] Dictionary<GameObject, int> _tileDictionary = new();
        [SerializeField] private int[] _openedSpriteArray;
        [SerializeField] GameObject[] _tempGameObject;
        private bool _oneSpriteIsOpened;

        // Start is called before the first frame update
        void Start()
        {
            if ( _row % 2 == 1)
            {
                _row++;
            }
            if (_column % 2 == 1)
            {
                _column++;
            }

            SetSpriteArray();
            SpawnTile();
            AddToTileDictionary();
            _openedSpriteArray = new int[2];
            _tempGameObject = new GameObject[2];
            _oneSpriteIsOpened = false;
        }

        void SpawnTile()
        {
            for (int x = 0; x < _row; x++)
            {
                for (int y = 0; y < _column; y++)
                {
                    var spawnedTile = Instantiate(_tile, new Vector2(x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.AddComponent<TileObject>();
                    _tiles[new Vector2(x, y)] = spawnedTile;
                    //_tileList.Add(spawnedTile);
                    spawnedTile.transform.parent = gameObject.transform;
                }
            }

            // centering
            foreach (GameObject _o in _tiles.Values)
            {
                _o.transform.position -= new Vector3(_row / 2, _column / 4);
                //_o.GetComponent<SpriteRenderer>().sprite
                //Debug.Log(_o.transform.position);
            }
        }

        void SetTileTheme()
        {
            // theme di load dari save data
        }

        void SetSpriteArray()
        {
            spriteArray = new int[(_row * _column)];

            // get first half of spriteArray
            for (int arrayFirstHalf = 0; arrayFirstHalf < (_row * _column) / 2; arrayFirstHalf++)
            {
                int randomIndex = Random.Range(0, tileAtlas.spriteCount);
                spriteArray[arrayFirstHalf] = randomIndex;
            }

            // clone first half to second half of spriteArray
            for (int arraySecondHalf = (_row * _column) / 2; arraySecondHalf < (_row * _column); arraySecondHalf++)
            {
                spriteArray[arraySecondHalf] = spriteArray[arraySecondHalf - (_row * _column) / 2];
            }

            // shuffle spriteArray
            for (int i = 0; i < spriteArray.Length; i++)
            {
                int rnd = Random.Range(0, spriteArray.Length);
                int tempGO = spriteArray[rnd];
                spriteArray[rnd] = spriteArray[i];
                spriteArray[i] = tempGO;
                
            }
        }

        void AddToTileDictionary()
        {
            int i = 0;
            foreach (GameObject _o in _tiles.Values)
            {
                _tileDictionary[_o] = spriteArray[i];
                i++;
            }
        }

        public Sprite ChangeSprite(GameObject gameObject)
        {
            var myKey = _tileDictionary[gameObject];
            Debug.Log(myKey);

            string tileAtlasName = tileAtlas.name;
            CheckOpenedTile(gameObject, myKey);

            return tileAtlas.GetSprite(tileAtlasName + "_" + spriteArray[myKey]);
        }

        void CheckOpenedTile(GameObject game, int index)
        {
            if (_oneSpriteIsOpened)
            {
                _openedSpriteArray[1] = spriteArray[index];
                _tempGameObject[1] = game;

                if (_openedSpriteArray[0] == _openedSpriteArray[1])
                {
                    Debug.Log("match");

                    for (int i = 0; i < _tempGameObject.Length; i++)
                    {
                        _tempGameObject[i].SetActive(false);
                        _tempGameObject[i] = null;
                    }
                    
                }
                else
                {
                    for (int i = 0; i < _tempGameObject.Length; i++)
                    {
                        _tempGameObject[i] = null;
                    }
                }
                _oneSpriteIsOpened = false;
            }
            else
            {
                _openedSpriteArray[0] = spriteArray[index];
                _tempGameObject[0] = game;
                _oneSpriteIsOpened = true;
            }
        }
    }
}