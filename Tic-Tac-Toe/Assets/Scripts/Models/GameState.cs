using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameState
    {
        public Board.Map currentMap;
        public List<Player> players;
        public int round = 0;
        public int currentPlayer;
        public List<Move> movesMade = new List<Move>();
    }
}