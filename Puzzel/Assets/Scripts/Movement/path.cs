using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class path : MonoBehaviour {

	public List<Vector3> openList, closedList;
	private GameObject[] xArray, zArray;
	public GameObject spawnPrefab, save;
	private float offSet = 10f; 

	private void Start()
	{
		xArray = new GameObject[7];
		zArray = new GameObject[6];
		makeGrid();

	}
	

	private void makeGrid()
	{
		for(int x=0; x < xArray.Length ;x++)
		{
			for(int z=0; z < zArray.Length; z++)
			{
				save = Instantiate(spawnPrefab,new Vector3(x * offSet,0,z * offSet),Quaternion.identity) as GameObject;
				//print(save.GetComponent<Collider>().name);
			}
		}
	}

	private void OnCollisonEnter(Collision col)
	{
		if(col.gameObject)
		{
			print("getCol");
		}
	}
}
