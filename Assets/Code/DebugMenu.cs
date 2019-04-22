using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebugMenu : MonoBehaviour
{
	[SerializeField] private int defaultStep = 1;
	[SerializeField] private UnityEvent OnStepDecreaseEvent;
	[SerializeField] private UnityEvent OnStepIncreaseEvent;

	public static Action OnStepChange = delegate { };
	public static readonly List<State> steps = new List<State>
	{
		new State { text = "Introduction", color = new Color32(255, 160, 116, 116) },
		new State { text = "Basic animations and sound", color = new Color32(255, 160, 124, 116) },
		new State { text = "Lower enemy hp", color = new Color32(255, 160, 132, 116) },
		new State { text = "Higher rate of fire", color = new Color32(255, 160, 140, 116) },
		new State { text = "More enemies", color = new Color32(255, 168, 140, 116) },
		new State { text = "Bigger bullets", color = new Color32(255, 176, 140, 116) }
	};
	public int currentStepIndex { get; private set; }

	private void Awake()
	{
		if (OnStepDecreaseEvent == null)
		{
			OnStepDecreaseEvent = new UnityEvent();
		}
		if (OnStepIncreaseEvent == null)
		{
			OnStepIncreaseEvent = new UnityEvent();
		}
	}

	private void Start()
	{
		ChangeStep(defaultStep);
	}

	private void Update()
	{
		if (Input.GetButtonDown("DebugPrev"))
		{
			DecreaseStep();
		}
		else if (Input.GetButtonDown("DebugNext"))
		{
			IncreaseStep();
		}
	}

	private void DecreaseStep()
	{
		var newIndex = Math.Max(currentStepIndex - 1, 0);
		ChangeStep(newIndex);
	}

	private void IncreaseStep()
	{
		var newIndex = Math.Min(currentStepIndex + 1, steps.Count - 1);

		OnStepIncreaseEvent.Invoke();
		ChangeStep(newIndex);
	}

	private void ChangeStep(int step)
	{
		// Don't play any sound on the first step.
		if (step != 0)
		{
			if (currentStepIndex < step)
			{
				OnStepIncreaseEvent.Invoke();
			}
			else if (currentStepIndex > step)
			{
				OnStepDecreaseEvent.Invoke();
			}
		}

		currentStepIndex = step;
		OnStepChange();
	}

	public class State
	{
		public string text;
		public Color32 color;
	}
}
