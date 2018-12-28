using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class TileDisplay : MonoBehaviour
    {
        [SerializeField]
        PlayerDisplay playerDisplay;

        [SerializeField]
        GameObject emptyDisplay;

        [SerializeField]
        GameObject highlightDisplay;

        [SerializeField]
        Text debugLocation;

        GameControler gameControler;

        public int x;
        public int y;

        [SerializeField]
        int width = 100;
        [SerializeField]
        int height = 100;

        public void Configure(int x, int y, GameControler gameControler)
        {
            this.x = x;
            this.y = y;
            this.gameControler = gameControler;
            RemoveHighlight();

            emptyDisplay.SetActive(true);
            playerDisplay.gameObject.SetActive(false);
            debugLocation.text = string.Format("{0}x {1}y", x, y);

            // Move to a position relative to it's position in the grid
            transform.localPosition = new Vector2((x + 1) * width, (y + 1) * height);
        }

        /// <summary>
        /// Set player to the tile
        /// </summary>
        /// <param name="player"></param>
        void SetPlayer(Player player)
        {
            emptyDisplay.SetActive(false);
            playerDisplay.gameObject.SetActive(true);
            playerDisplay.player = player;
        }

        /// <summary>
        /// Click this tile to make a move
        /// </summary>
        public void PickTile()
        {
            Player moveMaker = gameControler.currentPlayer;
            if (gameControler.MakeMove(x, y))
            {
                SetPlayer(moveMaker);
            }
        }

        public void Highlight()
        {
            highlightDisplay.SetActive(true);
        }

        public void RemoveHighlight()
        {
            highlightDisplay.SetActive(false);
        }
    }
}
