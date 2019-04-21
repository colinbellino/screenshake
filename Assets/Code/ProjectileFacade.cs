using UnityEngine;

public class ProjectileFacade : MonoBehaviour
{
	private Shooter _shooter;

	public Shooter Shooter => _shooter;

	public void SetShooter(Shooter shooter)
	{
		_shooter = shooter;
	}
}
