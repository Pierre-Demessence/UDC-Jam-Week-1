using UnityEngine;

public class Runner : MiniGame
{
	private Character _character;
	private EnemySpawner _enemySpawner;
	[SerializeField] private float _enemySpeed = 3;

	protected override void StartMinigame(int level)
	{
		base.StartMinigame(level);
		_enemySpawner.Speed = _enemySpeed + (level % 5);
		_enemySpawner.Run();
	}

	protected override void ResetMinigame()
	{
		_character.Reset();
		_enemySpawner.StopSpawningThings();
	}

	protected override void Awake()
	{
		base.Awake();
		_character = GetComponentInChildren<Character>();
		_enemySpawner = GetComponentInChildren<EnemySpawner>();
	}

	public override void TheButtonAction()
	{
		_character.Jump();
	}
}