using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace MatchPicture.Tile
{
    public class TileGroup : MonoBehaviour
    {
        [SerializeField] private int column;
        [SerializeField] private int row;
        [SerializeField] private GameObject tile;
        [SerializeField] private int themeID;
        [SerializeField] private SpriteAtlas tileAtlas;
        //[SerializeField] private Dictionary<Vector2, GameObject> _tiles = new Dictionary<Vector2, GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            themeID = 0;
            SpawnTile(themeID);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SpawnTile(int id)
        {
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < column; y++)
                {
                    var spawnedTile = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.AddComponent<TileObject>();
                    //_tiles[new Vector2(x, y)] = spawnedTile;
                    //spawnedTile.transform.parent = gameObject.transform;
                }
            }

            // centering
            //foreach (GameObject _o in _tiles.Values)
            //{
            //    _o.transform.position -= new Vector3(_width / 2, _height / 4);
            //    //Debug.Log(_o.transform.position);
            //}
        }
    }
}