using UnityEngine;

public class Pong : MiniGame
{
    private Ball _ball;
    [SerializeField] private float _ballSpeed = 3;
    private Paddle _paddle;
    [SerializeField] private float _paddleSpeed = 3;

    protected override void StartMinigame(int level)
    {
        base.StartMinigame(level);
        _ball.Speed = _ballSpeed + (level % 5);
        _paddle.Speed = _paddleSpeed + (level  % 5);
        _ball.Run();
        _paddle.Run();
    }

    protected override void ResetMinigame()
    {
        _ball.Reset();
        _paddle.Reset();
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