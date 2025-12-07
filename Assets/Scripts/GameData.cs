using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameData : MonoBehaviour
{
	public float	Timer_Time = 0f;
	public bool		Timer_CanTick = false;
	public TMP_Text	Timer_TimerDisplay;

	public Transform	Level_Marble;
	public Transform	Level_StartPoint;
	public bool			Level_HasFinishedRace = false;
}
