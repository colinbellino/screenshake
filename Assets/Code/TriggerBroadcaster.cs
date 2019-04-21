using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBroadcaster : MonoBehaviour
{
	public Action<Collider2D> OnTriggerEnterEvent;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (OnTriggerEnterEvent != null)
		{
			OnTriggerEnterEvent(collider);
		}
	}
}
