using UnityEngine;

public class Move : StepMonoBehaviour
{
	[SerializeField] private float speed = 1f;

	private float jumpTimestamp;
	private const float jumpCooldown = 0.2f;

	protected override void OnDisable()
	{
		base.OnDisable();

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
