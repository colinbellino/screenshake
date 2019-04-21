using UnityEngine;

public class ProjectileFacade : MonoBehaviour
{
	[SerializeField] private AudioClip _impactClip;

	private Shooter _shooter;
	private AudioSource _audioSource;

	public Shooter Shooter => _shooter;

	private void OnEnable()
	{
		// Crappy way to do this, but this is a prototype.
		_audioSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();
	}

	public void SetShooter(Shooter shooter)
	{
		_shooter = shooter;
	}

	public void PlayImpactClip() => _audioSource.PlayOneShot(_impactClip);
}
