using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int health = 1;

	private void OnEnable()
	{
		Damage.OnDamage += OnDamage;
	}

	private void OnDisable()
	{
		Damage.OnDamage -= OnDamage;
	}

	private void OnDamage(Transform target, int damage)
	{
		if (target != transform) { return; }

		// TODO: Trigger sound
		// TODO: Trigger animation
		health = Math.Max(health - damage, 0);

		if (health == 0)
		{
			// TODO: Trigger sound
			// TODO: Trigger animation
			Destroy(gameObject);
		}
	}
}
