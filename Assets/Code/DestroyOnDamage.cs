using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnDamage : MonoBehaviour
{
	[SerializeField] private SpriteRenderer projectileRenderer;
	[SerializeField] private Collider2D collider;
	[SerializeField] private Animator impactAnimator;
	[SerializeField] private float destroyAfter = 1f;

	public void PlayImpactAnimation()
	{
		if (impactAnimator)
		{
			impactAnimator.Play("Impact");
		}

		projectileRenderer.enabled = false;
		collider.enabled = false;
		StartCoroutine(DestroyAfterDelay());
	}

	private IEnumerator DestroyAfterDelay()
	{
		yield return new WaitForSeconds(destroyAfter);

		Destroy(transform.root.gameObject);
	}
}
