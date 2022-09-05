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
        [SerializeField] private List<GameObject> _tileList = new();

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
                    _tileList.Add(spawnedTile);
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

        public Sprite ChangeSprite(GameObject gameObject)
        {
            var myKey = _tileList.IndexOf(gameObject);
            Debug.Log(myKey);

            string tileAtlasName = tileAtlas.name;
            return tileAtlas.GetSprite(tileAtlasName + "_" + spriteArray[myKey]);
        }
    }
}