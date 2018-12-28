using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameControler : MonoBehaviour
    {
        /// <summary>
        /// Test for move legality.
        /// </summary>
        /// <param name="move">Move Position</param>
        /// <param name="gameState">Current game state</param>
        /// <returns>True is legal, False if illegal</returns>
        bool CheckLegal(Move move, GameState gameState)
        {
            // Bounds Check
            if (move.x > gameState.currentMap.Count - 1 || move.x < 0)
                return false;
            if (move.y > gameState.currentMap[move.x].Count - 1 || move.y < 0)
                return false;

            // Empty check
            if (gameState.currentMap[move.x][move.y] == Board.empty)
                return true;
            return false;
        }

        /// <summary>
        /// Check if move is a winning move
        /// </summary>
        /// <param name="move">Move position</param>
        /// <param name="gameState">Current game state</param>
        /// <returns>True if the move would win the match, false is not a win</returns>
        bool CheckWin(Move move, GameState gameState)
        {
            // Check Horizontal for win

            // Check Vertical for win

            // Check Positive Diagnal for win

            // Check Negative Diagnal for win
        }
    }
}
