using System;
using UnityEngine;

public class CameraStuff : MonoBehaviour
{
	[SerializeField] private Vector3 offset;

	private GameObject target;

	private void OnEnable()
	{
		target = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
		transform.position = target.transform.position + offset;
	}
}
