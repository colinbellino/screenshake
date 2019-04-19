using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField] private float speed = 1f;

	private IInput input;
	private CharacterController2D controller;
	private Animator animator;

	private void Start()
	{
		input = GetComponent<IInput>();
		controller = GetComponent<CharacterController2D>();
		animator = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		controller.Move(input.move * speed * Time.deltaTime, false, input.jump);

		if (animator)
		{
			if (input.move != 0f)
			{
				animator.SetFloat("MoveX", input.move > 0f ? 1f : -1f);
			}
		}

	}
}
