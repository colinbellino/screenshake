using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
	[SerializeField] private GameObject playerStep0;
	[SerializeField] private GameObject playerStep1;

	private int currentIndex;

	private Dictionary<int, DebugState> steps = new Dictionary<int, DebugState>();
	public static Action OnStepChange;

	private void Awake()
	{
		steps.Add(0, new DebugState
		{
			Enter = () =>
				{
					playerStep0.SetActive(true);
				},
				Leave = () =>
				{
					playerStep0.SetActive(false);
				}
		});
		steps.Add(1, new DebugState
		{
			Enter = () =>
				{
					playerStep1.SetActive(true);
				},
				Leave = () =>
				{
					playerStep1.SetActive(false);
				}
		});
	}

	private void Update()
	{
		if (Input.GetButtonDown("DebugPrev"))
		{
			PreviousStep();
		}
		else if (Input.GetButtonDown("DebugNext"))
		{
			NextStep();
		}
	}

	private void PreviousStep()
	{
		Debug.Log("PreviousStep -> " + currentIndex);
		var newIndex = Math.Max(currentIndex - 1, 0);

		steps[currentIndex].Leave();
		steps[newIndex].Enter();

		currentIndex = newIndex;
		OnStepChange();
	}

	private void NextStep()
	{
		Debug.Log("NextStep -> " + currentIndex);
		var newIndex = Math.Min(currentIndex + 1, steps.Count);

		steps[currentIndex].Leave();
		steps[newIndex].Enter();

		currentIndex = newIndex;
		OnStepChange();
	}
}

public class DebugState
{
	public Action Enter;
	public Action Leave;
}
