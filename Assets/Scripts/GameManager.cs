using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _lives = 5;
    [SerializeField] private Text _textlLives;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private List<MiniGame> _miniGames = new List<MiniGame>();

    public int Lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            _textlLives.text = Lives.ToString();
            if (Lives == 0)
                GameOver();
        }
    }

    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Awake()
    {
        _gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        _textlLives.text = Lives.ToString();
    }

    private void Start()
    {
        _miniGames.OrderBy(game => System.Guid.NewGuid()).First().StartMinigame();
    }

    public void OnTheButtonClicked()
    {
        _miniGames.ForEach(game => game.OnTheButtonClicked());
    }
}