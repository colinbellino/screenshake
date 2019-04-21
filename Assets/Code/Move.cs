using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField] private float speed = 1f;

	private IInput input;
	private CharacterController2D controller;
	private float jumpTimestamp;
	private const float jumpCooldown = 0.2f;

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
		var jumpCooldownElapsed = Time.time >= jumpTimestamp;

		controller.Move(input.move * speed * Time.deltaTime, false, input.jump && jumpCooldownElapsed);

		if (input.jump && jumpCooldownElapsed)
		{
			jumpTimestamp = Time.time + jumpCooldown;
		}
	}
}
