using UnityEngine;

public class AudioSourceFacade : MonoBehaviour
{
	private AudioSource audioSource;

	private void OnEnable()
	{
		// Crappy way to do this, but this is a prototype.
		audioSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();
	}

	public void PlayOneShot(AudioClip clip) => audioSource.PlayOneShot(clip);
}
