using MatchPicture.Tile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MatchPicture.InputModule
{
    public class InputRaycast : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Raycasting();
            }
        }

        void Raycasting()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Tile"))
            {
                // Debug.Log(hit.collider.name);
                hit.collider.GetComponent<TileObject>().OnRaycasted();
            }
        }
    }
}