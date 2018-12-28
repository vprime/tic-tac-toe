using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public const int empty = 0;

        public class Map : List<List<int>>
        {
            public int rows;
            public int columns;
            public int defaultData;

            public int area
            {
                get
                {
                    return rows * columns;
                }
            }

            public Map(int rows, int columns, int defaultData)
            {
                this.rows = rows;
                this.columns = columns;
                this.defaultData = defaultData;

                // Generate Columns
                for (var iX = 0; iX < columns; iX++)
                {
                    List<int> column = new List<int>();
                    // Generate Rows
                    for (var iY = 0; iY < rows; iY++)
                    {
                        column.Add(defaultData);
                    }
                    Add(column);
                }
            }

            public void Set(int x, int y, int data)
            {
                this[x][y] = data;
            }

            /// <summary>
            /// Traverse a row
            /// </summary>
            /// <param name="index"></param>
            /// <param name="map"></param>
            /// <returns></returns>
            public List<int> Row(int index)
            {
                List<int> response = new List<int>();
                for(var i=0; i < Count; i++)
                {
                    response.Add(this[i][index]);
                }
                return response;
            }

            /// <summary>
            /// Traverse a column
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public List<int> Column(int index)
            {
                return this[index];
            }

            /// <summary>
            /// Traverse a diagnal.
            /// </summary>
            /// <param name="direction">Movement along row per column.</param>
            /// <param name="map"></param>
            /// <returns></returns>
            public List<int> Diagnal(int direction)
            {
                List<int> response = new List<int>();
                int rowIndex = 0;
                if (direction < 0)
                    rowIndex = this[0].Count - 1;
                for (var i = 0; i < Count; i++)
                {
                    response.Add(this[i][rowIndex]);
                    rowIndex += direction;
                }
                return response;
            }
        }

        /// <summary>
        /// Generator for game boards
        /// </summary>
        /// <returns>Valid empty game map</returns>
        public Map GenerateMap()
        {
            Map response = new Map(columns, rows, empty);
            return response;
        }

        /// <summary>
        /// Test for move legality.
        /// </summary>
        /// <param name="move">Move Position</param>
        /// <param name="Board.Map">Current map state</param>
        /// <returns>True is legal, False if illegal</returns>
        public static bool CheckLegal(Move move, Map map)
        {
            // Bounds Check
            if (move.x > map.Count - 1 || move.x < 0)
                return false;
            if (move.y > map.Count - 1 || move.y < 0)
                return false;

            // Empty check
            if (map[move.x][move.y] == Board.empty)
                return true;
            return false;
        }



        /// <summary>
        /// Check if the map holds a win
        /// </summary>
        /// <param name="Board.Map">Current map</param>
        /// <returns>Returns the winner</returns>
        public static int CheckWin(Map map)
        {
            int winner = map.defaultData;

            // Check each row for win
            for (var i = 0; i < map.rows; i++)
            {
                winner = WinnerInList(map.Row(i));
            }

            // Check each column for a win
            for (var i = 0; i < map.columns; i++)
            {
                winner = WinnerInList(map.Column(i));
            }

            // Check Positive Diagnal for win
            winner = WinnerInList(map.Diagnal(1));

            // Check Negative Diagnal for win
            winner = WinnerInList(map.Diagnal(-1));

            return winner;
        }

        /// <summary>
        /// Check the list to see if it's a winning row.
        /// </summary>
        /// <param name="positions">List of player indexes from a row</param>
        /// <returns>The winner's index, or Board.empty</returns>
        static int WinnerInList(List<int> positions)
        {
            // Add the positions in the array
            int total = positions.Sum();
            // Compare with the first element multiplied by the row
            if (positions[0] * positions.Count == total)
                return positions[0];
            // If they don't match, they don't win.
            return Board.empty;
        }

    }
}
