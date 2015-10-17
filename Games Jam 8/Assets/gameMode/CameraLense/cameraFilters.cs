using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CAMERA_LENSE
{
	NORMAL_LENSE,
	RED_LENSE,
	BLUE_LENSE
};

public class cameraFilters : MonoBehaviour {

	public List<GameObject> normView, redView, blueView;
	public CAMERA_LENSE cameraLense;

	private void Start()
	{
		activateCamera.checkCamera += checkCameraState;
	}

	private void checkCameraState()
	{
		//print (cameraLense = checkingLense(cameraSwitch(activateCamera.stateSwitch)));
		cameraLense = checkingLense(cameraSwitch(activateCamera.stateSwitch));
	}

	private CAMERA_LENSE checkingLense(CAMERA_LENSE change)
	{
		switch(change)
		{
			case CAMERA_LENSE.NORMAL_LENSE:
				checkObjects(normView, true);
				checkObjects(redView, false);
				checkObjects(blueView, false);
				break;
			case CAMERA_LENSE.RED_LENSE:
				checkObjects(normView, false);
				checkObjects(redView, true);
				checkObjects(blueView, false);
				break;
			case CAMERA_LENSE.BLUE_LENSE:
				checkObjects(normView, false);
				checkObjects(redView, false);
				checkObjects(blueView, true);
				break;
		}
		return change;
	}
	
	private CAMERA_LENSE cameraSwitch(int change)
	{
		switch(change)
		{
			case 0:
				return CAMERA_LENSE.NORMAL_LENSE;
			case 1:
				return CAMERA_LENSE.RED_LENSE;
			case 2:
				return CAMERA_LENSE.BLUE_LENSE;
		}
		return cameraLense;
	}

	private void checkObjects(List<GameObject> localArray, bool isOn)
	{
		for(int i=0; i < localArray.Count; i++)
		{
			localArray[i].SetActive(isOn);
		}
	}
}