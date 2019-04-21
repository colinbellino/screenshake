using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int health = 1;

	private Transform owner;

	private void OnEnable()
	{
		owner = transform.root;

		Damage.OnDamage += OnDamage;
	}

	private void OnDisable()
	{
		Damage.OnDamage -= OnDamage;
	}

	private void OnDamage(Transform target, int damage)
	{
		if (target != transform.root) { return; }

		// TODO: Trigger animation
		health = Math.Max(health - damage, 0);

		if (health == 0)
		{
			// TODO: Trigger sound
			// TODO: Trigger animation
			Destroy(owner.gameObject);
		}
	}
}
