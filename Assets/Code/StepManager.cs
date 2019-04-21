using UnityEngine;

public class StepManager : MonoBehaviour
{
	private DebugMenu debugMenu;

	private void Awake()
	{
		debugMenu = GameObject.Find("Game Manager").GetComponent<DebugMenu>();

		DisableAllSteps();
		EnableCurrentStep();
	}

	private void OnEnable()
	{
		DebugMenu.OnStepChange += OnStepChange;
	}

	private void OnDisable()
	{
		DebugMenu.OnStepChange -= OnStepChange;
	}

	private void OnStepChange()
	{
		Debug.Log("OnStepChange " + debugMenu.currentStep);
		DisableAllSteps();
		EnableCurrentStep();
	}

	private void DisableAllSteps()
	{
		for (int i = 0; i < DebugMenu.stepsCount; i++)
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
		var current = transform.Find($"Step{debugMenu.currentStep}");
		if (current != null)
		{
			foreach (var component in current.GetComponents<MonoBehaviour>())
			{
				component.enabled = true;
			}
		}
	}

	public T GetComponentInStep<T>()
	{
		var stepTransform = transform.Find($"Step{debugMenu.currentStep}");
		if (stepTransform == null)
		{
			var step0Transform = transform.Find("Step0");
			if (step0Transform != null)
			{
				Debug.LogWarning($"{transform.name}: Defaulting to \"Step0\".");
				return step0Transform.GetComponent<T>();
			}

			Debug.LogError($"{transform.name}: Step not found \"Step{debugMenu.currentStep}\".");
			return GetComponent<T>();
		}

		return stepTransform.GetComponent<T>();
	}
}
