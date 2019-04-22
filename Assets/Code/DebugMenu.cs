using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebugMenu : MonoBehaviour
{
	[SerializeField] private int defaultStep = 1;
	[SerializeField] private UnityEvent OnStepDecreaseEvent;
	[SerializeField] private UnityEvent OnStepIncreaseEvent;

	public static Action OnStepChange = delegate { };
	public static readonly List<State> steps = new List<State>
	{
		new State { text = "0 - Introduction", color = new Color32(255, 70 + 0 * 6, 116, 116) },
		new State { text = "1 - Basic animations and sound", color = new Color32(255, 70 + 1 * 6, 116, 116) },
		new State { text = "2 - Lower enemy hp", color = new Color32(255, 70 + 2 * 6, 116, 116) },
		new State { text = "3 - Higher rate of fire", color = new Color32(255, 70 + 3 * 6, 116, 116) },
		new State { text = "4 - More enemies", color = new Color32(255, 70 + 4 * 6, 116, 116) },
		new State { text = "5 - Bigger bullets", color = new Color32(255, 70 + 5 * 6, 116, 116) },
		new State { text = "6 - Muzzle flash", color = new Color32(255, 70 + 6 * 6, 116, 116) },
		new State { text = "7 - Faster bullets", color = new Color32(255, 70 + 7 * 6, 116, 116) },
		new State { text = "8 - Less accuracy", color = new Color32(255, 70 + 8 * 6, 116, 116) },
		new State { text = "9 - Impact effect", color = new Color32(255, 70 + 9 * 6, 116, 116) },
		new State { text = "10 - Hit animation", color = new Color32(255, 70 + 10 * 6, 116, 116) },
		new State { text = "11 - Enemy knockback", color = new Color32(255, 70 + 11 * 6, 116, 116) },
		new State { text = "12 - Permanence", color = new Color32(255, 70 + 12 * 6, 116, 116) },
		new State { text = "13 - Camera lerp", color = new Color32(255, 70 + 13 * 6, 116, 116) },
		new State { text = "14 - Camera position", color = new Color32(255, 70 + 14 * 6, 116, 116) },
		new State { text = "15 - Screen shake", color = new Color32(255, 70 + 15 * 6, 116, 116) },
		new State { text = "16 - Player knockback", color = new Color32(255, 70 + 16 * 6, 116, 116) },
		new State { text = "17 - Sleep", color = new Color32(255, 70 + 17 * 6, 116, 116) },
		new State { text = "18 - Weapon delay", color = new Color32(255, 70 + 18 * 6, 116, 116) },
		new State { text = "19 - Weapon kick", color = new Color32(255, 70 + 19 * 6, 116, 116) },
		new State { text = "20 - Strafe", color = new Color32(255, 70 + 20 * 6, 116, 116) },
		new State { text = "21 - More permanence", color = new Color32(255, 70 + 21 * 6, 116, 116) },
		new State { text = "22 - More bass", color = new Color32(255, 70 + 22 * 6, 116, 116) },
		new State { text = "23 - Super machine guns", color = new Color32(255, 70 + 23 * 6, 116, 116) },
		new State { text = "24 - Random explosion", color = new Color32(255, 70 + 24 * 6, 116, 116) },
		new State { text = "25 - Faster enemies", color = new Color32(255, 70 + 25 * 6, 116, 116) },
		new State { text = "26 - More enemies", color = new Color32(255, 70 + 26 * 6, 116, 116) },
		new State { text = "27 - Even higher rate of fire and camera kick", color = new Color32(255, 70 + 27 * 6, 116, 116) },
		new State { text = "28 - Bigger explosions", color = new Color32(255, 70 + 28 * 6, 116, 116) },
		new State { text = "29 - Event more permanence", color = new Color32(255, 70 + 29 * 6, 116, 116) },
		new State { text = "30 - Meaning", color = new Color32(255, 70 + 30 * 6, 116, 116) }
	};
	public int currentStepIndex { get; private set; }

	private void Awake()
	{
		if (OnStepDecreaseEvent == null)
		{
			OnStepDecreaseEvent = new UnityEvent();
		}
		if (OnStepIncreaseEvent == null)
		{
			OnStepIncreaseEvent = new UnityEvent();
		}
	}

	private void Start()
	{
		ChangeStep(defaultStep);
	}

	private void Update()
	{
		if (Input.GetButtonDown("DebugPrev"))
		{
			DecreaseStep();
		}
		else if (Input.GetButtonDown("DebugNext"))
		{
			IncreaseStep();
		}
	}

	private void DecreaseStep()
	{
		var newIndex = Math.Max(currentStepIndex - 1, 0);
		ChangeStep(newIndex);
	}

	private void IncreaseStep()
	{
		var newIndex = Math.Min(currentStepIndex + 1, steps.Count - 1);

		OnStepIncreaseEvent.Invoke();
		ChangeStep(newIndex);
	}

	private void ChangeStep(int step)
	{
		// Don't play any sound on the first step.
		if (step != 0)
		{
			if (currentStepIndex < step)
			{
				OnStepIncreaseEvent.Invoke();
			}
			else if (currentStepIndex > step)
			{
				OnStepDecreaseEvent.Invoke();
			}
		}

		currentStepIndex = step;
		OnStepChange();
	}

	public class State
	{
		public string text;
		public Color32 color;
	}
}
