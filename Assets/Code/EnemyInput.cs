using UnityEngine;

public class EnemyInput : MonoBehaviour, IInput
{
	private float _move;
	private bool _jump;
	private bool _shoot;

	public float move => _move;
	public bool jump => _jump;
	public bool shoot => _shoot;

	public void SetMove(float value) 
	{
		_move = value;
	}
}
