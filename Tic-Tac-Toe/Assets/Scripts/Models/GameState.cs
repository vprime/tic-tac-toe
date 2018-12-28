using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameState
    {
        public List<List<int>> currentMap;
        public List<Player> players;
        public int round;
    }
}