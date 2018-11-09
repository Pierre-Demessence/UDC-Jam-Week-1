using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _lives = 5;
    [SerializeField] private Text _textlLives;
    [SerializeField] private List<MiniGame> _miniGames = new List<MiniGame>();

    public int Lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            _textlLives.text = Lives.ToString();
        }
    }

    private void Awake()
    {
        _textlLives.text = Lives.ToString();
    }

    public void OnTheButtonClicked()
    {
        _miniGames.ForEach(game => game.OnTheButtonClicked());
    }
}