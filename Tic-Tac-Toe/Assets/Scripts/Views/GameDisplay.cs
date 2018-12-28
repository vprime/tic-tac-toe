using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameDisplay : MonoBehaviour
    {
        [SerializeField]
        PlayerDisplay currentPlayerDisplay;

        [SerializeField]
        GameObject drawPanel;

        [SerializeField]
        GameObject winnerPanel;

        [SerializeField]
        PlayerDisplay winningPlayer;

        [SerializeField]
        BoardDisplay boardDisplay;

        public void UpdateCurrentPlayer(Player player)
        {
            currentPlayerDisplay.player = player;
        }

        public void Win(List<Board.Map.Tile> tilesToHighlight, Player winner)
        {
            winnerPanel.SetActive(true);
            winningPlayer.player = winner;
            boardDisplay.HighlightTiles(tilesToHighlight);
        }

        public void Draw()
        {
            drawPanel.SetActive(true);
        }
    }
}
