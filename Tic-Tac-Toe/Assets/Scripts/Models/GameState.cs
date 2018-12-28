using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameState
    {
        public Board.Map currentMap;
        public LinkedList<Player> players;
        public int round = -1;
        public LinkedListNode<Player> currentPlayer;
        public List<Move> movesMade = new List<Move>();
    }
}