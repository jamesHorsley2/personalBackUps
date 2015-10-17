using UnityEngine;
using System.Collections;
public enum TAKE_PHOTO
{
	CAN_TAKE_RED_PHOTO,
	CAN_TAKE_BLUE_PHOTO,
	NO_PHOTO
};

public class allowUses : MonoBehaviour {

	private TAKE_PHOTO photoCheck;
	public GameObject cameraVision;
	private bool activateCamera = false;
	public int redCount, blueCount;
	public cameraFilters cameraChecker;


	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			checkPhoto(checkIfCanTakePhoto(redCount, blueCount));
		}
		else
		{
			checkIfCanTakePhoto(redCount,blueCount);
		}
	}

	private TAKE_PHOTO checkPhoto(TAKE_PHOTO change)
	{
		switch (change)
		{
			case TAKE_PHOTO.CAN_TAKE_RED_PHOTO:
				redCount --;
				takePhoto();
				break;

			case TAKE_PHOTO.CAN_TAKE_BLUE_PHOTO:
				blueCount --;
				takePhoto();
				break;

			case TAKE_PHOTO.NO_PHOTO:
				break;
		}
		return change;
	}
	
	private TAKE_PHOTO checkIfCanTakePhoto(int red, int blue)
	{
		if(cameraChecker.cameraLense == CAMERA_LENSE.RED_LENSE)
		{
			if(red > 0)
			{
				return TAKE_PHOTO.CAN_TAKE_RED_PHOTO;
			}
			else
			{
				cameraChecker.cameraLense = CAMERA_LENSE.NORMAL_LENSE;
				return TAKE_PHOTO.NO_PHOTO;
			}
		}

		if(cameraChecker.cameraLense == CAMERA_LENSE.BLUE_LENSE)
		{
			if(blue > 0)
			{
				return TAKE_PHOTO.CAN_TAKE_BLUE_PHOTO;
			}
			else
			{
				cameraChecker.cameraLense = CAMERA_LENSE.NORMAL_LENSE;
				return TAKE_PHOTO.NO_PHOTO;
			}
		}

		if(cameraChecker.cameraLense == CAMERA_LENSE.NORMAL_LENSE)
		{
			return TAKE_PHOTO.NO_PHOTO;
		}

		return photoCheck;
	}

	public int addLense(int lense)
	{
		return lense + 1;
	}

	private void takePhoto()
	{
		activateCamera = true;
		if(activateCamera)
		{
			cameraVision.SetActive(true);
			activateCamera =! activateCamera;
		}
	}
}
