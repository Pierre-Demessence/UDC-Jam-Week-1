using UnityEngine;

public class Pong : MiniGame
{
    [SerializeField] private Paddle _paddle;
    
    public override void OnTheButtonClicked()
    {
        _paddle.ReverseDirection();
    }
}