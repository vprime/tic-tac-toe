using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacToe
{
    public class GameControler : MonoBehaviour
    {
        GameState currentState;

        public Player currentPlayer
        {
            get
            {
                return currentState.players[currentState.currentPlayer];
            }
            set
            {
                currentState.players[currentState.currentPlayer] = value;
            }
        }
        public Board.Map currentMap
        {
            get
            {
                return currentState.currentMap;
            }
        }

        [SerializeField]
        Board mapBoard;

        [SerializeField]
        GameDisplay gameDisplay;

        [SerializeField]
        int numberOfPlayers = 2;

        bool playerChange = true;
        bool gameOver = false;

        private void Awake()
        {
            
            currentState = new GameState();
            currentState.currentMap = mapBoard.GenerateMap();
            
            // Create a link list of players
            currentState.players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                currentState.players.Add(new Player());
            }

            // set the first player
            currentState.currentPlayer = 0;
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
                if (currentPlayer.symbol == null)
                    SetupCurrentPlayer();
                else
                    CallCurrentPlayer();

                Debug.Log(currentState.currentMap.area);
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
        public bool MakeMove(int x, int y)
        {
            Move move = new Move();
            move.player = currentPlayer;
            move.x = x;
            move.y = y;

            // Stop if the move is illegal
            if (!Board.CheckLegal(move, currentState.currentMap))
                return false;
            
            // Set the move to the map
            currentState.currentMap.Set(move.x, move.y, currentState.currentPlayer);

            // Check if the map has a winner
            List<Board.Map.Tile> winningTiles = null;
            int winner = Board.CheckWin(currentState.currentMap, out winningTiles);
            if (winner != Board.empty)
                AnnounceWinner(winner, winningTiles);

            // Change to the next player
            playerChange = true;
            IteratePlayer();

            // Set the round up
            currentState.round++;
            return true;
        }

        /// <summary>
        /// Iterate the current player
        /// </summary>
        void IteratePlayer()
        {
            currentState.currentPlayer++;
            if (currentState.currentPlayer >= numberOfPlayers)
                currentState.currentPlayer = 0;
        }

        /// <summary>
        /// Opens a view to setup the player
        /// </summary>
        void SetupCurrentPlayer()
        {
            currentPlayer.symbol = ScriptableObject.CreateInstance<Symbol>();
            // Just set something random for now
            currentPlayer.symbol.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
            currentPlayer.index = currentState.currentPlayer;
            CallCurrentPlayer();
        }

        /// <summary>
        /// Update the UI to indicate the current player's turn
        /// </summary>
        void CallCurrentPlayer()
        {
            Debug.Log("Player " + currentState.currentPlayer.ToString() + " Turn");
            gameDisplay.UpdateCurrentPlayer(currentPlayer);
        }

        /// <summary>
        /// Announces a winner among the players
        /// </summary>
        /// <param name="winnerID"></param>
        void AnnounceWinner(int winnerID, List<Board.Map.Tile> winningTiles)
        {
            gameOver = true;
            Debug.Log("Player " + winnerID + " has won!");
            gameDisplay.Win(winningTiles, currentPlayer);
        }

        /// <summary>
        /// Announce the game as a draw
        /// </summary>
        void GameDraw()
        {
            gameOver = true;
            Debug.Log("Game was a draw");
            gameDisplay.Draw();
        }
    }
}
