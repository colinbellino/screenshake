using UnityEngine;

public class EnemyInput : MonoBehaviour, IInput
{
	private float _move;
	private bool _jump;

	public float move => _move;
	public bool jump => _jump;

	public void SetMove(float value) 
	{
		_move = value;
	}
}
