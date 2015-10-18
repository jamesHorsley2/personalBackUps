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
	
	public CAMERA_LENSE cameraLense;
	public List<GameObject> objectsInScene, normView, redView, blueView;

	private void Awake()
	{
		activateCamera.checkCamera += checkCameraState;
	}

	private void Start()
	{
		checker();
	}

	private void checker()
	{
		objectsInScene.AddRange(GameObject.FindGameObjectsWithTag("Object"));
		int length = objectsInScene.Count;
		for(int i=0; i <length -2; i+=3)
		{
			grabObjectsFromScene(normView, Random.Range (0,objectsInScene.Count));
			grabObjectsFromScene(redView, Random.Range (0,objectsInScene.Count));
			grabObjectsFromScene(blueView, Random.Range (0,objectsInScene.Count));
		}
	}
		
	private void grabObjectsFromScene(List<GameObject> localList, int which)
	{
		localList.Add (objectsInScene[which].gameObject as GameObject);
		objectsInScene.RemoveAt(which);
	}
	
	private void checkCameraState()
	{
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

	private int random(List<GameObject> localArray)
	{
		int randomPoint = Random.Range(0,localArray.Count);
		localArray.RemoveAt(randomPoint);
		return randomPoint;
	}
/*
	private int randomArrayPoint(List<GameObject> ayy)
	{
		int randomPoint = Random.Range(0,)
		return
	}
*/

	private void checkObjects(List<GameObject> localArray, bool isOn)
	{
		for(int i=0; i < localArray.Count; i++)
		{
			localArray[i].SetActive(isOn);
		}
	}
}