using UnityEngine;

public class StepAnimator : MonoBehaviour
{
	[SerializeField] private RuntimeAnimatorController _controller;

	public RuntimeAnimatorController controller => _controller;
}
