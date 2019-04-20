using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private float rateOfFire = 0.1f;
	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private Transform projectileOrigin;

	private IInput input;
	private CharacterController2D controller;
	private float fireTimestamp;

	private void Start()
	{
		input = GetComponent<IInput>();
		controller = GetComponent<CharacterController2D>();
	}

	private void Update()
	{
		if (input.shoot && Time.time > fireTimestamp)
		{
			FireProjectile();
			fireTimestamp = Time.time + rateOfFire;
		}
	}

	private void FireProjectile()
	{
		var projectile = GameObject.Instantiate(
			projectilePrefab,
			projectileOrigin.position,
			transform.rotation
		);
	}
}
