using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    [CreateAssetMenu(fileName = "DEFAULT - Symbol", menuName = "TicTacToe/Player Symbol")]
    public class Symbol : ScriptableObject
    {
        /// <summary>
        /// Image of player's symbol
        /// </summary>
        public Sprite sprite;

        /// <summary>
        /// Background color for player
        /// </summary>
        public Color color;
    }
}
