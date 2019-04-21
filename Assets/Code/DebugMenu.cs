using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
	private int currentIndex;
	private int max = 29;

	private void Update()
	{
		if (Input.GetButtonDown("DebugPrev"))
		{
			currentIndex = Math.Max(currentIndex - 1, 0);
			TransitionTo();
		}
		else if (Input.GetButtonDown("DebugNext"))
		{
			currentIndex = Math.Min(currentIndex + 1, max);
			TransitionTo();
		}
	}

	private void TransitionTo()
	{
		Debug.Log("-> " + currentIndex);

		if (currentIndex == 0)
		{
			Debug.Log("0");
		}

		if (currentIndex == 1)
		{
			Debug.Log("1");
		}
	}
}
