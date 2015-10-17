using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateGoal : MonoBehaviour
{
	public ObjectChanger objectChanger;

	public string assignTarget()
	{
		GameObject[] objectsInScene = objectChanger.getObjectsInScene();

		int i = Random.Range(0, objectsInScene.Length);

		return objectsInScene[i].name; 
	}
}