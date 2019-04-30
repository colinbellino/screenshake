using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : StepMonoBehaviour
{
	[SerializeField] private float rateOfFire = 0.1f;
	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private Transform projectileOrigin;
	[SerializeField] private Animator muzzleFlashAnimator;
	[SerializeField] private float spread = 0f;
	[SerializeField] private float knockback = 0f;
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
			Knockback();

			fireTimestamp = Time.time + rateOfFire;
		}
	}

	private void Knockback()
	{
		if (knockback > 0)
		{
			rb.AddForce(Vector3.right * -1 * knockback);
		}
	}

	private void FireProjectile()
	{
		var instance = GameObject.Instantiate(
			projectilePrefab,
			projectileOrigin.position,
			GetProjectileRotation()
		);

		var projectileFacade = instance.GetComponent<ProjectileFacade>();
		projectileFacade.SetShooter(this);

		OnFireEvent.Invoke();
		if (muzzleFlashAnimator)
		{
			muzzleFlashAnimator.Play("Flash");
		}
	}

	private Quaternion GetProjectileRotation()
	{
		var rotation = transform.root.rotation;
		rotation.z = rotation.z + UnityEngine.Random.Range(-spread, spread);

		return rotation;
	}
}
