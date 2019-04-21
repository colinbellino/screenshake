using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField] private TMPro.TextMeshProUGUI currentStepText;
	[SerializeField] private SpriteRenderer backgroundRenderer;
	[SerializeField] private Animator animator;

	private DebugMenu debugMenu;

	private void OnEnable()
	{
		debugMenu = GetComponent<DebugMenu>();

		DebugMenu.OnStepChange += OnStepChange;
	}

	private void OnDisable()
	{
		DebugMenu.OnStepChange -= OnStepChange;
	}

	private void OnStepChange()
	{
		currentStepText.text = DebugMenu.steps[debugMenu.currentStepIndex].text;
		backgroundRenderer.color = DebugMenu.steps[debugMenu.currentStepIndex].color;

		Show();
	}

	private void Show()
	{
		animator.Play("Show");
	}
}
