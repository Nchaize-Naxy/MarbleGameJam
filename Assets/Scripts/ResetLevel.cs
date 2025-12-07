using UnityEngine;
using UnityEngine.InputSystem;

public class ResetLevel : MonoBehaviour
{
	public GameData				GameData;
	public Rigidbody			rb;

	private ResetLevelInputs	reset;

	void	Start()
	{
		reset = new ResetLevelInputs();

		reset.Keyboard.ResetLevel.started += restart;
		reset.Enable();
	}

	void	OnDestroy()
	{
		reset.Keyboard.ResetLevel.started -= restart;
		reset.Disable();
	}

	void	restart(InputAction.CallbackContext context)
	{
		GameData.Level_Marble.position = GameData.Level_StartPoint.position;
		GameData.Timer_CanTick = false;
		GameData.Timer_Time = 0f;
		GameData.Timer_TimerDisplay.color = new Color(1f, 1f, 1f, 1f);
		rb.linearVelocity = new Vector3(0, 0, 0);
	}
}

