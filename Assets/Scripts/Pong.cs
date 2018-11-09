using UnityEngine;

public class Pong : MiniGame
{
    private Ball _ball;
    private Paddle _paddle;

    [SerializeField] private float _ballSpeed = 3;
    [SerializeField] private float _paddleSpeed = 3;

    public override void StartMinigame()
    {
        base.StartMinigame();
        _ball.Speed = _ballSpeed;
        _paddle.Speed = _paddleSpeed;
        _ball.Init();
        _paddle.Init();
    }

    protected override void OnFail()
    {
        base.OnFail();
    }

    protected override void Awake()
    {
        base.Awake();
        _paddle = GetComponentInChildren<Paddle>();
        _ball = GetComponentInChildren<Ball>();
    }

    public override void TheButtonAction()
    {
        _paddle.ReverseDirection();
    }
    
    
}