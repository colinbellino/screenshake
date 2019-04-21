using UnityEngine;

public class ImpulseMove : MonoBehaviour
{
	[SerializeField] private float speed = 10f;

	private Rigidbody2D rb;
	private Transform owner;

	private void OnEnable()
	{
		rb = GetComponentInParent<Rigidbody2D>();
		owner = GetComponentInParent<Transform>();
	}

	private void Update()
	{
		rb.velocity = owner.right * speed;
	}
}
