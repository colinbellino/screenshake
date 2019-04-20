using UnityEngine;

[RequireComponent(typeof(EnemyInput))]
public class EnemyAI : MonoBehaviour
{
	[SerializeField] private MoveDirection initialMoveDirection;
	[SerializeField] private Transform collisionTrigger;

	private EnemyInput input;
	private bool isGoingLeft;
	private float direction => isGoingLeft ? -1f : 1f;

	private void Start()
	{
		input = GetComponent<EnemyInput>();

		isGoingLeft = initialMoveDirection == MoveDirection.Left;
	}

	private void Update()
	{
		input.SetMove(direction);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Block") || collider.CompareTag("Player"))
		{
			isGoingLeft = !isGoingLeft;
			collisionTrigger.localPosition = new Vector3(
				1f - collisionTrigger.localPosition.x,
				collisionTrigger.localPosition.y,
				collisionTrigger.localPosition.z
			);
		}
	}
}

public enum MoveDirection
{
	Left,
	Right
}
