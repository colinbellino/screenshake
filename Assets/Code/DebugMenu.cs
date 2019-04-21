using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
	[SerializeField] private int defaultStep = 1;

	public int currentStep { get; private set; }
	public const int stepsCount = 2;

	public static Action OnStepChange = delegate { };

	private void Start()
	{
		ChangeStep(defaultStep);
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
		var newIndex = Math.Max(currentStep - 1, 0);

		ChangeStep(newIndex);
	}

	private void NextStep()
	{
		var newIndex = Math.Min(currentStep + 1, stepsCount - 1);

		ChangeStep(newIndex);
	}

	private void ChangeStep(int step)
	{
		currentStep = step;
		OnStepChange();
	}
}
