using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
	private float _move;
	private bool _jump;

	public float move => _move;
	public bool jump => _jump;

	private void Update()
	{
		_move = Input.GetAxis("Horizontal");
		_jump = Input.GetButtonDown("Jump");
	}
}
