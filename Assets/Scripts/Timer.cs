using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
	public GameData	GameData;

	private float	mins = 0f;
	private float	secs10 = 0f;
	private float	secs1 = 0f;
	private	float	millis100 = 0f;
	private float	millis10 = 0f;

    private void	Update()
    {
        if (GameData.Timer_CanTick == true)
		{
			GameData.Timer_Time += Time.deltaTime;
		}

		mins = Mathf.Floor(GameData.Timer_Time / 60);
		secs10 = Mathf.Floor(GameData.Timer_Time / 10 % 6);
		secs1 = Mathf.Floor(GameData.Timer_Time % 10);
		millis100 = Mathf.Floor(GameData.Timer_Time * 10 % 10);
		millis10 = Mathf.Floor(GameData.Timer_Time * 100 % 100 % 10);

		GameData.Timer_TimerDisplay.SetText(mins.ToString() + ":" + secs10.ToString() + secs1.ToString() + ":" + millis100.ToString() + millis10.ToString());
    }

	private void	OnTriggerEnter(Collider collider)
	{
		GameData.Timer_CanTick = !GameData.Timer_CanTick;
	}
}
