using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Sleep : MonoBehaviour
{
	private float timestamp;

	public void SleepForSeconds(float duration)
	{
		timestamp = Time.realtimeSinceStartup + duration;
	}

	private void Update()
	{
		if (timestamp == 0f) { return; }

		if (Time.realtimeSinceStartup > timestamp)
		{
			Time.timeScale = 1f;
			return;
		}

		Time.timeScale = 0f;
	}
}
