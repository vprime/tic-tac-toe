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

        /// <summary>
        /// Get a tile from the list
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        TileDisplay GetTile(int x, int y)
        {
            foreach(var tile in tiles)
            {
                if (tile.x == x && tile.y == y)
                    return tile;
            }
            return null;
        }

        /// <summary>
        /// Highlight tiles
        /// </summary>
        /// <param name="tilesToHighlight"></param>
        public void HighlightTiles(List<Board.Map.Tile> tilesToHighlight)
        {
            foreach(var tile in tilesToHighlight)
            {
                TileDisplay tileDisplay = GetTile(tile.x, tile.y);
                if (tileDisplay != null)
                    tileDisplay.Highlight();
            }
        }
    }
}