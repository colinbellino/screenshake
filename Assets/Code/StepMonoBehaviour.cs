using System;
using UnityEngine;

public class StepMonoBehaviour : MonoBehaviour
{
	private StepManager stepManager;

	protected Rigidbody2D rb;
	protected IInput input;
	protected TriggerBroadcaster triggerBroadcaster;
	protected CharacterController2D controller;

	protected virtual void OnEnable()
	{
		stepManager = GetComponentInParent<StepManager>();
		rb = GetComponentInParent<Rigidbody2D>();
		input = GetComponentInParent<IInput>();
		triggerBroadcaster = GetComponentInParent<TriggerBroadcaster>();

		DebugMenu.OnStepChange += OnStepChange;
	}

	protected virtual void OnDisable()
	{
		DebugMenu.OnStepChange -= OnStepChange;
	}

	private void UpdateStepComponents()
	{
		controller = stepManager.GetComponentInStep<CharacterController2D>();
	}

	private void OnStepChange()
	{
		UpdateStepComponents();
	}
}
