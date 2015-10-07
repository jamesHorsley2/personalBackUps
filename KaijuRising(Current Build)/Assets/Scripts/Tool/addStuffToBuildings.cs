using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class addStuffToBuildings : MonoBehaviour {

	public List<Material> materialList;
	public bool run;
	public Material ayy;
	public Material one,two,three, four, five, six, seven, eight;
	public GameObject[] checkingIfBuilding;
	//public DestroyBuilding[] checkingIfBuilding;

	private void Update()
	{
		if(run)
		checkAllBuildings();
	}

	private void checkAllBuildings()
	{
		//checkingIfBuilding= GameObject.FindObjectsOfType<DestroyBuilding>() as DestroyBuilding[];//gets all buildings in the scene
		/*
		for(int i=0; i<checkingIfBuilding.Length; i++)
		{
			checkingIfBuilding[i].tag = "Building";
		}
		*/
		checkingIfBuilding = GameObject.FindGameObjectsWithTag("Building");
		//material = new Shader[checkingIfBuilding.Length];
		//findMaterial = GameObject.FindObjectsOfType<Material>() as Material[];


		for(int i=0; i< checkingIfBuilding.Length; i++)
		{
			ayy = checkingIfBuilding[i].GetComponent<Renderer>().sharedMaterial;
			/*
			if(checkingIfBuilding[i].GetComponent<Renderer>() == null)
			{
				//print (" not there");
				checkingIfBuilding[i].tag = "Untagged";
				//DestroyImmediate(checkingIfBuilding[i].GetComponentInParent<DestroyBuilding>());
			}
			*/


			if(ayy != null)
			{
				print(ayy);
				if(ayy == one) 
				{
					print("found");
				}
				
				if(ayy == two) 
				{
					print ("found the second tallest buildings");
				}
				
				if(ayy == three) 
				{
					print ("found the tallest buildings");
				}
			}

			/*
			if(findMaterial[i] == one) 
			{
				print("found");
			}

			if(findMaterial[i] == two) 
			{
				print ("found the second tallest buildings");
			}

			if(findMaterial[i] == three) 
			{
				print ("found the tallest buildings");
			}
			*/
		}
	}
	
}

				/*
				print ("found the smallest buildings");
				newThing = findMaterial[i].gameObject.GetComponent<Renderer>();
				if(newThing != null)
					//gameObjectList. = newThing.GetComponent<GameObject>();
					//gameObjectList.Add (new GameObject()newThing.GetComponent<GameObject>());
					thing = newThing.GetComponent<GameObject>();
					if(thing != null)
					{
						print ("acutally there");
					}
				*/

