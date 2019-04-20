using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
	private float _move;
	private bool _jump;
	private bool _shoot;

	public float move => _move;
	public bool jump => _jump;
	public bool shoot => _shoot;

	private void Update()
	{
		_move = Input.GetAxis("Horizontal");
		_jump = Input.GetButton("Jump");
		_shoot = Input.GetButton("Fire1");
	}
}
