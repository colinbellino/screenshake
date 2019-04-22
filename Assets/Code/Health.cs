using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int health = 1;

	private Transform owner;
	private Animator animator;
	private Rigidbody2D rb;

	public static Action<Transform> OnDeathEvent = delegate { };

	private void OnEnable()
	{
		owner = transform.root;
		animator = GetComponentInParent<Animator>();
		rb = GetComponentInParent<Rigidbody2D>();

		Damage.OnDamage += OnDamage;
	}

	private void OnDisable()
	{
		Damage.OnDamage -= OnDamage;
	}

	private void OnDamage(Transform target, int damage)
	{
		if (target != owner) { return; }

		health = Math.Max(health - damage, 0);

		if (animator)
		{
			animator.Play("Hit");
		}

		if (health <= 0)
		{
			// TODO: Trigger sound
			// TODO: Trigger animation
			OnDeathEvent.Invoke(owner);
		}
	}
}
