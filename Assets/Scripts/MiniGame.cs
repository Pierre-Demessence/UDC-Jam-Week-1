using UnityEngine;

public abstract class MiniGame : MonoBehaviour
{
    private PauseOverlay _pauseOverlay;
    private bool _paused = true;
    private GameManager _gameManager;

    public bool Paused
    {
        get { return _paused; }
        set
        {
            _paused = value;
            _pauseOverlay.Paused = value;
        }
    }
    public abstract void TheButtonAction();

    public void OnTheButtonClicked()
    {
        if (Paused) return;
        TheButtonAction();
    }

    public virtual void StartMinigame()
    {
        Paused = false;
    }
    
    public virtual void StopMinigame()
    {
        Paused = true;
    }

    protected virtual void OnFail()
    {
        _gameManager.Lives--;
    }

    protected virtual void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _pauseOverlay = GetComponentInChildren<PauseOverlay>();
        _pauseOverlay.Paused = Paused;
    }
}