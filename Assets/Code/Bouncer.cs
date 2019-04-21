using UnityEngine;
using UnityEngine.Events;

public class Bouncer : StepMonoBehaviour
{
	[SerializeField] private int damage = 1;
	[SerializeField] private float cooldown = 0.3f;
	[SerializeField] private float bounceForce = 1000f;
	[SerializeField] private UnityEvent OnBounceEvent;

	private float bounceTimestamp;

	private void Awake()
	{
		if (OnBounceEvent == null)
		{
			OnBounceEvent = new UnityEvent();
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();

		triggerBroadcaster.OnTriggerEnterEvent += OnTriggerEnterEvent;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		triggerBroadcaster.OnTriggerEnterEvent -= OnTriggerEnterEvent;
	}

	private void OnTriggerEnterEvent(Collider2D collider)
	{
		if (Time.time <= bounceTimestamp ||  rb.velocity.y >= 0) { return; }

		// Debug.Log("Bounce : " + name + " => " + collider.transform.root.name);
		rb.AddForce(new Vector2(0f, bounceForce));
		Damage.OnDamage.Invoke(collider.transform.root, damage);
		OnBounceEvent.Invoke();

		bounceTimestamp = Time.time + cooldown;
	}
}
