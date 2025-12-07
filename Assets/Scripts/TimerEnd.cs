using UnityEngine;

public class TimerEnd : MonoBehaviour
{
	public GameData	GameData;

	private void	OnTriggerEnter(Collider collider)
	{
		GameData.Timer_CanTick = false;
		GameData.Timer_TimerDisplay.color = new Color(0.968f, 0.901f, 0.376f, 1f);
	}
}
