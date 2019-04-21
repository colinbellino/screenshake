using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
	[SerializeField] private int defaultStep = 1;

	public static Action OnStepChange = delegate { };
	public static readonly List<State> steps = new List<State>
	{
		new State { text = "Introduction", color = new Color32(255, 160, 116, 116) },
		new State { text = "Basic animations and sound", color = new Color32(255, 160, 124, 116) }
	};
	public int currentStepIndex { get; private set; }

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
		var newIndex = Math.Max(currentStepIndex - 1, 0);

		ChangeStep(newIndex);
	}

	private void NextStep()
	{
		var newIndex = Math.Min(currentStepIndex + 1, steps.Count - 1);

		ChangeStep(newIndex);
	}

	private void ChangeStep(int step)
	{
		currentStepIndex = step;
		OnStepChange();
	}

	public class State
	{
		public string text;
		public Color32 color;
	}
}
