using System;
using UnityEngine;

public class Damage : MonoBehaviour
{
	[SerializeField] private int damage = 1;

	private ProjectileFacade projectileFacade;

	public static Action<Transform, int> OnDamage;

	private void OnEnable()
	{
		projectileFacade = GetComponent<ProjectileFacade>();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.transform == projectileFacade.Shooter.transform) { return; }

		// Debug.Log(projectileFacade.Shooter.transform.root.name + " > " + name + " => " + collider.transform.root.name);
		OnDamage.Invoke(collider.transform.root, damage);

		// TODO: Trigger sound
		// TODO: Trigger animation
		Destroy(gameObject);
	}
}
