using UnityEngine;

public class Move : StepMonoBehaviour
{
	[SerializeField] private float speed = 1f;
	[SerializeField] private bool knockback;

	private Transform owner;
	private const float jumpCooldown = 0.2f;
	private const float hitStopDuration = 0.2f;
	private float jumpTimestamp;
	private float hitStopTimetamp;

	protected override void OnEnable()
	{
		base.OnEnable();

		owner = transform.root;

		Damage.OnDamage += OnDamage;
	}

	protected override void OnDisable()
	{
		base.OnDisable();

		controller.Move(0f, false, false);

		Damage.OnDamage -= OnDamage;
	}

	private void FixedUpdate()
	{
		var jumpCooldownElapsed = Time.time >= jumpTimestamp;

		if (Time.time < hitStopTimetamp) { return; }

		controller.Move(input.move * speed * Time.deltaTime, false, input.jump && jumpCooldownElapsed);

		if (input.jump && jumpCooldownElapsed)
		{
			jumpTimestamp = Time.time + jumpCooldown;
		}
	}

	private void OnDamage(Transform target, int damage)
	{
		if (target != owner) { return; }

		if (knockback)
		{
			rb.AddForce(new Vector3(owner.right.x * -2f, 0, 0f), ForceMode2D.Impulse);
			hitStopTimetamp = Time.time + hitStopDuration;
		}
	}
}
