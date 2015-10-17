using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectChanger : MonoBehaviour
{
	public GameObject[] objectPrefabs;
	public string objectTag;

	public GameObject[] getObjectsInScene()
	{
		return GameObject.FindGameObjectsWithTag(objectTag);
	}

	private void Start()
	{
		chooseMeshes();
	}

	private void changeMesh(GameObject changer, GameObject swapper)
	{
		changer.GetComponent<MeshFilter>().mesh = swapper.GetComponent<MeshFilter>().sharedMesh;
	}

	private void chooseMeshes()
	{
		//Creating two Local Lists to cycle through the objects

		List<GameObject> prefabObjects = new List<GameObject>();
		List<GameObject> sortObjects = new List<GameObject>();

		prefabObjects.AddRange(objectPrefabs);
		sortObjects.AddRange(objectPrefabs);

		GameObject[] objectsInScene = getObjectsInScene();

		for(int i = 0; i < objectPrefabs.Length; i++)
		{
			GameObject changingObject = prefabObjects[0];
			prefabObjects.RemoveAt(0);

			int o = Random.Range(0, sortObjects.Count);

			GameObject newObject = sortObjects[o];

			sortObjects.RemoveAt(o);

			for(int p = 0; p < objectsInScene.Length; p++)
			{
				if(objectsInScene[p].name == changingObject.name)
				{
					changeMesh(objectsInScene[p], newObject);
				}
			}
		}
	}
}