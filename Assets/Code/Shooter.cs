using System;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : StepMonoBehaviour
{
	[SerializeField] private float rateOfFire = 0.1f;
	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private Transform projectileOrigin;
	[SerializeField] private UnityEvent OnFireEvent;

	private float fireTimestamp;

	private void Awake()
	{
		if (OnFireEvent == null)
		{
			OnFireEvent = new UnityEvent();
		}
	}

	private void Update()
	{
		if (input.shoot && Time.time > fireTimestamp)
		{
			FireProjectile();
			OnFireEvent.Invoke();
			fireTimestamp = Time.time + rateOfFire;
		}
	}

	private void FireProjectile()
	{
		var instance = GameObject.Instantiate(
			projectilePrefab,
			projectileOrigin.position,
			transform.root.rotation
		);

		var projectileFacade = instance.GetComponent<ProjectileFacade>();
		projectileFacade.SetShooter(this);
	}
}
