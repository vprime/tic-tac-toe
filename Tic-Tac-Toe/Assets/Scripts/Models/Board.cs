using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    [CreateAssetMenu(fileName = "DEFAULT - Board", menuName = "TicTacToe/Game Board")]
    public class Board : ScriptableObject
    {
        /// <summary>
        /// Columns on a board (X Axis)
        /// </summary>
        public int columns = 3;

        /// <summary>
        /// Rows on a board (Y Axis)
        /// </summary>
        public int rows = 3;

        /// <summary>
        /// Empty space placeholder
        /// </summary>
        public const int empty = -1;

        /// <summary>
        /// Generator for game boards
        /// </summary>
        /// <returns>Valid empty game map</returns>
        public List<List<int>> GenerateMap()
        {
            List<List<int>> response = new List<List<int>>();

            // Generate Columns
            for (var iX = 0; iX < columns; iX++)
            {
                List<int> column = new List<int>();
                // Generate Rows
                for (var iY = 0; iY < rows; iY++)
                {
                    column.Add(empty);
                }
                response.Add(column);
            }

            return response;
        }
    }
}
