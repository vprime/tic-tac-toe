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
        public const int empty = -1;

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

            public struct Tile
            {
                public int x;
                public int y;
                public int value;

                public Tile(int x, int y, int value)
                {
                    this.x = x;
                    this.y = y;
                    this.value = value;
                }
            }

            public void Set(int x, int y, int value)
            {
                this[x][y] = value;
            }

            /// <summary>
            /// Traverse a row
            /// </summary>
            /// <param name="index"></param>
            /// <param name="map"></param>
            /// <returns></returns>
            public List<Tile> Row(int index)
            {
                List<Tile> response = new List<Tile>();
                for(var i=0; i < Count; i++)
                {
                    response.Add(new Tile(i, index, this[i][index]));
                }
                return response;
            }

            /// <summary>
            /// Traverse a column
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public List<Tile> Column(int index)
            {
                List<Tile> response = new List<Tile>();
                for (var i = 0; i < this[index].Count; i++)
                {
                    response.Add(new Tile(index, i, this[index][i]));
                }
                return response;
            }

            /// <summary>
            /// Traverse a diagnal.
            /// </summary>
            /// <param name="direction">Movement along row per column.</param>
            /// <param name="map"></param>
            /// <returns></returns>
            public List<Tile> Diagnal(int direction)
            {
                List<Tile> response = new List<Tile>();
                int rowIndex = 0;
                if (direction < 0)
                    rowIndex = this[0].Count - 1;
                for (var i = 0; i < Count; i++)
                {
                    response.Add(new Tile(i, rowIndex, this[i][rowIndex]));
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
        public static int CheckWin(Map map, out List<Map.Tile> winningTiles)
        {
            int winner = map.defaultData;
            List<List<Map.Tile>> pathsToTest = new List<List<Map.Tile>>();
            
            // Check each row for win
            for (var i = 0; i < map.rows; i++)
            {
                pathsToTest.Add(map.Row(i));
            }

            // Check each column for a win
            for (var i = 0; i < map.columns; i++)
            {
                pathsToTest.Add(map.Column(i));
            }

            // Check Positive Diagnal for win
            pathsToTest.Add(map.Diagnal(1));

            // Check Negative Diagnal for win
            pathsToTest.Add(map.Diagnal(-1));

            // Loop through the list
            foreach(List<Map.Tile> path in pathsToTest)
            {
                // Test for a winner
                int result = WinnerInList(path);
                if (result != map.defaultData)
                {
                    // Return the winner's ID and the winning tiles
                    winner = result;
                    winningTiles = path;
                    return winner;
                }
            }
            // No wins, return null tiles and default number
            winningTiles = null;
            return winner;
        }

        /// <summary>
        /// Check the list to see if it's a winning row.
        /// </summary>
        /// <param name="positions">List of player indexes from a row</param>
        /// <returns>The winner's index, or Board.empty</returns>
        static int WinnerInList(List<Map.Tile> positions)
        {
            int first = positions[0].value;
            if (first == Board.empty)
                return Board.empty;
            
            for (var i = 1; i < positions.Count; i++)
            {
                if (positions[i].value != first)
                    return Board.empty;
            }
            return first;
        }

    }
}
