using UnityEngine;

public class ImpulseMove : MonoBehaviour
{
	[SerializeField] private float speed = 10f;

	private Rigidbody2D rb;

	private void OnEnable()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		rb.velocity = transform.right * speed;
	}
}
