using UnityEngine;

public class Bouncer : MonoBehaviour
{
	[SerializeField] private int damage = 1;
	[SerializeField] private float cooldown = 0.3f;
	[SerializeField] private float bounceForce = 1000f;

	private Rigidbody2D rb;
	private float bounceTimestamp;

	private void OnEnable()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (Time.time <= bounceTimestamp ||  rb.velocity.y >= 0) { return; }

		// Debug.Log("Bounce : " + name + " => " + collider.transform.root.name);
		rb.AddForce(new Vector2(0f, bounceForce));
		Damage.OnDamage.Invoke(collider.transform.root, damage);
		bounceTimestamp = Time.time + cooldown;
	}
}
