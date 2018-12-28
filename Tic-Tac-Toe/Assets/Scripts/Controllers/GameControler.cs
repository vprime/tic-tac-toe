using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacToe
{
    public class GameControler : MonoBehaviour
    {
        GameState currentState;

        [SerializeField]
        Board mapBoard;

        [SerializeField]
        int numberOfPlayers = 2;

        bool playerChange = true;
        bool gameOver = false;

        private void Start()
        {
            currentState = new GameState();
            currentState.currentMap = mapBoard.GenerateMap();

            // Create a link list of players
            currentState.players = new LinkedList<Player>();
            currentState.players.AddFirst(new Player());
            for (int i = 1; i < numberOfPlayers; i++)
            {
                currentState.players.AddLast(new Player());
            }

            // Find the first player
            currentState.currentPlayer = currentState.players.First;
            
        }

        private void Update()
        {
            if (gameOver)
                return;

            // Trigger on a player change
            if (playerChange)
            {
                playerChange = false;

                // If the player hasn't setup yet, have them do it now
                if (currentState.currentPlayer.Value.symbol == null)
                    SetupCurrentPlayer();
                else
                    CallCurrentPlayer();
            }
            if (currentState.currentMap.area <= currentState.round)
            {
                GameDraw();
            }
        }

        /// <summary>
        /// Processes a move input from the user
        /// </summary>
        /// <param name="move"></param>
        public void MakeMove(int x, int y)
        {
            Move move = new Move();
            move.player = currentState.currentPlayer.Value;
            move.x = x;
            move.y = y;

            // Stop if the move is illegal
            if (!Board.CheckLegal(move, currentState.currentMap))
                return;
            
            // Set the move to the map
            currentState.currentMap.Set(move.x, move.y, move.player.GetHashCode());

            // Check if the map has a winner
            int winner = Board.CheckWin(currentState.currentMap);
            if (winner != Board.empty)
                AnnounceWinner(winner);

            // Change to the next player
            playerChange = true;
            currentState.currentPlayer = currentState.currentPlayer.Next;

            // Set the round up
            currentState.round++;
        }

        /// <summary>
        /// Opens a view to setup the player
        /// </summary>
        void SetupCurrentPlayer()
        {
            Debug.Log(currentState.currentPlayer.GetHashCode());
            currentState.currentPlayer.Value.symbol = ScriptableObject.CreateInstance<Symbol>();
            // Just set something random for now
            currentState.currentPlayer.Value.symbol.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
        }

        /// <summary>
        /// Update the UI to indicate the current player's turn
        /// </summary>
        void CallCurrentPlayer()
        {
            Debug.Log("Player " + currentState.currentPlayer.Value.GetHashCode().ToString() + " Turn");
        }

        /// <summary>
        /// Announces a winner among the players
        /// </summary>
        /// <param name="winnerID"></param>
        void AnnounceWinner(int winnerID)
        {
            gameOver = true;
            Debug.Log("Player " + winnerID + " has won!");
        }

        /// <summary>
        /// Announce the game as a draw
        /// </summary>
        void GameDraw()
        {
            gameOver = true;
            Debug.Log("Game was a draw");
        }
    }
}
