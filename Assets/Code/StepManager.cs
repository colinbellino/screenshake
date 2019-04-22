using System;
using UnityEngine;

public class StepManager : MonoBehaviour
{
	private DebugMenu debugMenu;
	private Animator animator;

	private void OnEnable()
	{
		debugMenu = GameObject.Find("Game Manager").GetComponent<DebugMenu>();
		animator = GetComponent<Animator>();

		DisableAllSteps();
		EnableCurrentStep();

		DebugMenu.OnStepChange += OnStepChange;
	}

	private void OnDisable()
	{
		DebugMenu.OnStepChange -= OnStepChange;
	}

	private void OnStepChange()
	{
		DisableAllSteps();
		EnableCurrentStep();
	}

	private void DisableAllSteps()
	{
		for (int i = 0; i < DebugMenu.steps.Count; i++)
		{
			var current = transform.Find($"Step{i}");
			if (current != null)
			{
				foreach (var component in current.GetComponents<MonoBehaviour>())
				{
					component.enabled = false;
				}
			}
		}
	}

	private void EnableCurrentStep()
	{
		var current = GetCurrentStep();

		if (current == null) { return; }

		foreach (var component in current.GetComponents<MonoBehaviour>())
		{
			component.enabled = true;
		}

		var stepAnimator = current.GetComponent<StepAnimator>();
		if (stepAnimator)
		{
			animator.runtimeAnimatorController = stepAnimator.controller;
		}
	}

	public T GetComponentInStep<T>()
	{
		return GetCurrentStep().GetComponent<T>();
	}

	private Transform GetCurrentStep()
	{
		// A quick and dirty hack because sometimes this is called before debugMenu is initialized..
		if (debugMenu == null)
		{
			Debug.LogError("Couldn't find debugMenu.");
			return null;
		}

		var index = debugMenu.currentStepIndex;

		var current = transform.Find($"Step{index}");
		if (current != null)
		{
			// Debug.Log($"{transform.name}: Get step (asked for {index}).");
			return current;
		}

		var previous = GetPreviousStep(index);
		if (previous != null)
		{
			// Debug.LogWarning($"{transform.name}: Defaulting to {previous.Item1} (asked for {index}).");
			return previous.Item2;
		}

		Debug.LogError($"{transform.name}: Step not found (asked for {index}).");
		return transform;
	}

	private Tuple<int, Transform> GetPreviousStep(int index)
	{
		for (int i = index - 1; i >= 0; i--)
		{
			var current = transform.Find($"Step{i}");
			if (current)
			{
				return new Tuple<int, Transform>(i, current);
			}
		}

		return null;
	}
}
