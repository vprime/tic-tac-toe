using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TicTacToe
{
    public class ResetButton : MonoBehaviour
    {
        /// <summary>
        /// Reset the current scene
        /// </summary>
        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
