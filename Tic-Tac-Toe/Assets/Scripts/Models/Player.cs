using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Player
    {
        /// <summary>
        /// Player's chosen symbol
        /// </summary>
        public Symbol symbol;

        public int index;

        public override string ToString()
        {
            return string.Format("{0}", index);
        }
    }
}
