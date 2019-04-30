using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	[SerializeField] private float spawnRate = 0.5f;
	[SerializeField] private int max = 3;

	private float nextSpawnTimestamp;
	private Transform owner;
	private List<Transform> children = new List<Transform>();

	private void OnEnable()
	{
		owner = transform.root;

		Health.OnDeathAction += OnDeath;
	}

	private void OnDisable()
	{
		Health.OnDeathAction -= OnDeath;

		ClearChildren();
	}

	private void ClearChildren()
	{
		if (children.Count > 0)
		{
			foreach (var child in children)
			{
				Destroy(child.gameObject);
			}
			children.Clear();
		}
	}

	private void Update()
	{
		if (Time.time > nextSpawnTimestamp && children.Count < max)
		{
			Spawn();
		}
	}

	private void Spawn()
	{
		var child = Instantiate(prefab, owner.position, owner.rotation);
		children.Add(child.transform);

		nextSpawnTimestamp = Time.time + spawnRate;
	}

	private void OnDeath(Transform owner)
	{
		if (!children.Contains(owner)) { return; }

		owner.gameObject.SetActive(false);
	}
}
