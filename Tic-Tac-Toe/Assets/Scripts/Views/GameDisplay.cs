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

        public void UpdateCurrentPlayer(Player player)
        {
            currentPlayerDisplay.player = player;
        }

        public void Win()
        {
            winnerPanel.SetActive(true);
        }

        public void Draw()
        {
            drawPanel.SetActive(true);
        }
    }
}
