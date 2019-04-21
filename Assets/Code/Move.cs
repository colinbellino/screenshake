using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField] private float speed = 1f;

	private IInput input;
	private CharacterController2D controller;

	private void OnEnable()
	{
		input = GetComponent<IInput>();
		controller = GetComponent<CharacterController2D>();
	}

	private void OnDisable()
	{
		controller.Move(0f, false, false);
	}

	private void FixedUpdate()
	{
		controller.Move(input.move * speed * Time.deltaTime, false, input.jump);
	}
}
