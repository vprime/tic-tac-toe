﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TicTacToe
{
    public class Move
    {
        /// <summary>
        /// Player who did the move
        /// </summary>
        public Player player;

        /// <summary>
        /// X Location
        /// </summary>
        public int x;

        /// <summary>
        /// Y Location
        /// </summary>
        public int y;

        /// <summary>
        /// Result of win check
        /// </summary>
        public bool winningMove;

        public override string ToString()
        {
            return string.Format("Player {0}: picks {1}, {2}", player, x, y);
        }
    }
}
