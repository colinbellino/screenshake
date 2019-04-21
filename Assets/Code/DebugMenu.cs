using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
	[SerializeField] private int defaultStep = 1;
	[SerializeField] private TMPro.TextMeshProUGUI currentStepText;
	[SerializeField] private SpriteRenderer backgroundRenderer;
	public static readonly List<State> steps = new List<State>
	{
		new State { text = "Introduction", color = new Color32(255, 160, 116, 116) },
		new State { text = "Basic animations and sound", color = new Color32(255, 160, 124, 116) }
	};

	public int currentStep { get; private set; }

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
		var newIndex = Math.Min(currentStep + 1, steps.Count - 1);

		ChangeStep(newIndex);
	}

	private void ChangeStep(int step)
	{
		currentStep = step;
		OnStepChange();

		currentStepText.text = steps[step].text;
		backgroundRenderer.color = steps[step].color;
	}

	public class State
	{
		public string text;
		public Color32 color;
	}
}
