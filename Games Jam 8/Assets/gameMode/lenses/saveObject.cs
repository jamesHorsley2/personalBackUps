using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class saveObject : MonoBehaviour {
	
	public cameraFilters filterObject;
	public allowUses getCameraCone;
	//public string[] tagArray;

	private void Awake()
	{
		getCameraCone = GetComponentInParent<allowUses>();
		filterObject = GameObject.FindGameObjectWithTag("filterControler").GetComponentInParent<cameraFilters>();
	}
	

	private void OnTriggerEnter(Collider col)
	{	
		if(filterObject.cameraLense == CAMERA_LENSE.BLUE_LENSE)
		{
			checkArray(col.gameObject,filterObject.blueView);
		}

		if(filterObject.cameraLense == CAMERA_LENSE.RED_LENSE)
		{
			checkArray(col.gameObject,filterObject.redView);
		}
	}

	private void checkArray(GameObject collidedObject, List<GameObject> arrayName)
	{
		for(int i=0; i< arrayName.Count; i++)
		{
			if(collidedObject.name == arrayName[i].name)
			{
				arrayName.RemoveAt(i);
			}
		}
	}
}
