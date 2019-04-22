using System;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Damage : MonoBehaviour
{
	[SerializeField] private int damage = 1;
	[SerializeField] private UnityEvent OnDamageEvent;
	public static Action<Transform, int> OnDamage;

	private TriggerBroadcaster triggerBroadcaster;
	private ProjectileFacade projectileFacade;
	private Transform owner;

	private void Awake()
	{
		if (OnDamageEvent == null)
		{
			OnDamageEvent = new UnityEvent();
		}
	}

	private void OnEnable()
	{
		triggerBroadcaster = GetComponentInParent<TriggerBroadcaster>();
		projectileFacade = GetComponentInParent<ProjectileFacade>();
		owner = transform.root;

		triggerBroadcaster.OnTriggerEnterEvent += OnTriggerEnterEvent;
	}

	protected void OnDisable()
	{
		triggerBroadcaster.OnTriggerEnterEvent -= OnTriggerEnterEvent;
	}

	private void OnTriggerEnterEvent(Collider2D collider)
	{
		if (collider.transform == projectileFacade.Shooter.transform) { return; }

		// Debug.Log(projectileFacade.Shooter.transform.root.name + " > " + name + " => " + collider.transform.root.name);
		OnDamage.Invoke(collider.transform.root, damage);
		OnDamageEvent.Invoke();
	}
}
