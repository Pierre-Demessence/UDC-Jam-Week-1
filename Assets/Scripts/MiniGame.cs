using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public abstract class MiniGame : MonoBehaviour
{
    private GameManager _gameManager;
    private PauseOverlay _pauseOverlay;
    [SerializeField] private float _resumeDelayTime = 3;
    private float _resumeTimeLeft = 0;
    private bool _running;
    [SerializeField] private Text _timer;
    private Coroutine _gameRestartCoroutine;
    private int _currentLevel;

    public bool Running
    {
        get { return _running; }
        set
        {
            _running = value;
            _pauseOverlay.Running = value;
            _timer.enabled = false;
        }
    }
    public abstract void TheButtonAction();

    public void OnTheButtonClicked()
    {
        if (!Running) return;
        TheButtonAction();
    }

    protected virtual void StartMinigame(int level)
    {
        _currentLevel = level;
        Running = true;
    }

    public void StopMinigame()
    {
        Running = false;
        if (_gameRestartCoroutine != null) StopCoroutine(_gameRestartCoroutine);
        ResetMinigame();
    }

    public void OnFail()
    {
        _gameManager.Lives--;
        StopMinigame();
        _gameRestartCoroutine = StartCoroutine(StartGameDelayed(_currentLevel));
    }

    protected virtual void Awake()
    {
        _timer.enabled = false;
        _gameManager = FindObjectOfType<GameManager>();
        _pauseOverlay = GetComponentInChildren<PauseOverlay>();
        _pauseOverlay.Running = Running;
    }

    protected abstract void ResetMinigame();

    public IEnumerator StartGameDelayed(int level)
    {   
        _resumeTimeLeft = _resumeDelayTime;
        _timer.enabled = true;

        while (_resumeTimeLeft > 0)
        {
            _timer.text = _resumeTimeLeft.ToString("0.00s", CultureInfo.InvariantCulture);
            _resumeTimeLeft -= Time.deltaTime;
            yield return null;
        }

        StartMinigame(level);
    }
}