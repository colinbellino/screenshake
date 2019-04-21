using System;
using UnityEngine;

public class CameraStuff : MonoBehaviour
{
	[SerializeField] private Vector3 offset;

	private GameObject target;

	private void OnEnable()
	{
		UpdateTarget();

		DebugMenu.OnStepChange += OnStepChange;
	}

	private void OnDisable()
	{
		DebugMenu.OnStepChange -= OnStepChange;
	}

	private void OnStepChange()
	{
		UpdateTarget();
	}

	private void UpdateTarget()
	{
		target = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
		transform.position = target.transform.position + offset;
	}
}
