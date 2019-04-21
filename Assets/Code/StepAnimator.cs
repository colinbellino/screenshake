using UnityEditor.Animations;
using UnityEngine;

public class StepAnimator : MonoBehaviour
{
	[SerializeField] private AnimatorController _controller;

	public AnimatorController controller => _controller;
}
