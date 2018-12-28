using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class PlayerDisplay : MonoBehaviour
    {
        [SerializeField]
        Text playerIDField;

        [SerializeField]
        Image playerBackground;

        [SerializeField]
        Image playerImage;

        [SerializeField]
        Player _player;

        public Player player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                Configure(_player);
            }
        }

        // Use this for initialization
        void Start()
        {
            if (_player != null)
                Configure(_player);
        }

        // Configure view
        void Configure(Player player)
        {
            playerIDField.text = player.index.ToString();
            playerBackground.color = player.symbol.color;
            playerImage.sprite = player.symbol.sprite;
        }
    }
}