using UnityEngine;

[DisallowMultipleComponent]
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

	private void OnDisable()
	{
		rb.velocity = Vector3.zero;
	}

	private void Update()
	{
		rb.velocity = owner.right * speed;
	}
}
