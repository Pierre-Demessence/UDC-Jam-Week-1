using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private readonly Dictionary<int, int> _miniGamesPerLevel = new Dictionary<int, int>
    {
        {1, 1},
        {5, 2},
        {10, 3},
        {15, 4}
    };
    [SerializeField] private GameObject _gameOverPanel;
    private float _levelTimeLeft;
    [SerializeField] private int _lives = 5;
    [SerializeField] private List<MiniGame> _miniGames = new List<MiniGame>();
    [SerializeField] private Text _textLevel;
    [SerializeField] private Text _textLives;
    [SerializeField] private float _timePerLevel = 10f;
    [SerializeField] private Text _timer;

    public int Lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            _textLives.text = Lives.ToString();
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
        _textLives.text = Lives.ToString();
    }

    private IEnumerable<MiniGame> SelectMiniGames(int level)
    {
        var numberOfMinigames = _miniGamesPerLevel.Last(pair => level >= pair.Key).Value;
        return _miniGames.OrderBy(minigame => Guid.NewGuid()).Take(numberOfMinigames).ToList();
    }

    private IEnumerator NewLevel(int level)
    {
        _miniGames.ForEach(miniGame => miniGame.StopMinigame());
        _textLevel.text = level.ToString();
        
        foreach (var miniGame in SelectMiniGames(level)) StartCoroutine(miniGame.StartGameDelayed());

        _levelTimeLeft = _timePerLevel;
        while (_levelTimeLeft > 0)
        {
            _timer.text = _levelTimeLeft.ToString("0.00s", CultureInfo.InvariantCulture);
            _levelTimeLeft -= Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Start()
    {
        var currentLevel = 0;
        while (true) yield return StartCoroutine(NewLevel(++currentLevel));
    }

    public void OnTheButtonClicked()
    {
        _miniGames.ForEach(game => game.OnTheButtonClicked());
    }
}