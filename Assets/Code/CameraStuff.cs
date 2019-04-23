using System;
using UnityEngine;

public class CameraStuff : MonoBehaviour
{
	[SerializeField] private Vector3 offset;
	[SerializeField] private GameObject target;

	private void Update()
	{
		transform.position = target.transform.position + offset;
	}
}
