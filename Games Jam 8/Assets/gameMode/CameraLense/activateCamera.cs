using UnityEngine;
using System.Collections;

public class activateCamera : MonoBehaviour {

	public static event ActivateCameraDelegate checkCamera;
	public delegate void ActivateCameraDelegate();
	public static int stateSwitch;

	private void Update()
	{
		checkKeys();
	}

	private void checkKeys()
	{
		if(Input.GetKey(KeyCode.Mouse2))
		{
			activateNormalState();
		}
		if(Input.GetKey(KeyCode.Mouse0))
		{
			activateRedState();
		}
		if(Input.GetKey(KeyCode.Mouse1))
		{
			activateBlueState();
		}
	}

	private void activateNormalState()
	{
		stateSwitch = 0;
		checkCamera();
	}
	
	private void activateRedState()
	{
		stateSwitch = 1;
		checkCamera();
	}
	
	private void activateBlueState()
	{
		stateSwitch = 2;
		checkCamera();
	}


}
