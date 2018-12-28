using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class BoardDisplay : MonoBehaviour
    {
        List<TileDisplay> tiles = new List<TileDisplay>();

        [SerializeField]
        GameControler gameControler;

        [SerializeField]
        GameObject tilePrefab;

        private void Start()
        {
            AddTiles();
        }

        /// <summary>
        /// Step through the map and create tiles
        /// </summary>
        void AddTiles()
        {
            for (var x = 0; x < gameControler.currentMap.Count; x++)
            {
                for (var y = 0; y < gameControler.currentMap[x].Count; y++)
                {
                    GameObject newTile = Instantiate(tilePrefab, transform);
                    tiles.Add(newTile.GetComponent<TileDisplay>());
                    tiles[tiles.Count - 1].Configure(x, y, gameControler);
                }
            }
        }
    }
}