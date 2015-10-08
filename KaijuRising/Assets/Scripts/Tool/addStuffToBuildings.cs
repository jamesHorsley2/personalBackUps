using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum MODE
{
	FIND_BUILDINGS,
	CHANGE_BUILDING_INFO
};

[ExecuteInEditMode]
public class addStuffToBuildings : MonoBehaviour {

	[Header("buildings and changing info")]
	[Header("Controls to switch between finding")]
	public MODE change;
	[Header("Put the tag name of the desired")]
	[Header("Building / GameObject")]
	public string buildingTag;
	public bool run;
	private Material tempPlacement;

	//for these material variables here, please place the correct material for each building
	//what this will do will be used to check buildings/gameObject and will class them based on a certain
	//type they are
	public Material fiftyMMaterial,hundredMMaterial,hundredFiftyMMaterial, noMaterialColour, aqaductsMaterial;
	
	private Color fiftyMColour, hundredMColour, hundredFiftyMColour, noColour, aqaductsColour;
	public GameObject[] checkingIfBuilding;
	public List<GameObject> smallestBuildings, secondLargest, tallestBuilding, unColoured, aquaduct;

	private void Update()
	{
		if(run)
		{
			switch(change)
			{
				case MODE.CHANGE_BUILDING_INFO:
					changeBuildingInfo();
					break;
				case MODE.FIND_BUILDINGS:
					checkAllBuildings();
					break;
			}
			run =! run;
		}
	}

	private void changeBuildingInfo()
	{
		print ("Not avaliable Yet");
		//gives the buildings inside the list new properties, including Tag + Name
		/*
		for(int q=0; q< smallestBuildings.Count; q++)
		{
			print ("scaned1");
			smallestBuildings[q].gameObject.name = "50m";
			smallestBuildings[q].gameObject.tag = "50m";
		}
		for(int q=0; q< secondLargest.Count; q++)
		{
			print ("scaned22");
			secondLargest[q].gameObject.name = "100m";
			secondLargest[q].gameObject.tag = "100m";
		}
		for(int q=0; q< tallestBuilding.Count; q++)
		{
			print ("scaned3");
			tallestBuilding[q].gameObject.name = "150m";
			tallestBuilding[q].gameObject.tag = "150m";

		}
		for(int q=0; q< unColoured.Count; q++)
		{
			print ("scaned4");
			unColoured[q].gameObject.name = "UnColouredBuilding";
			unColoured[q].gameObject.tag = "UnColouredBuilding";

		}
		for(int q=0; q< aquaduct.Count; q++)
		{
			print ("scaned5");
		}
		*/
	}

	private void checkAllBuildings()
	{
		checkingIfBuilding = GameObject.FindGameObjectsWithTag(buildingTag);
	
		fiftyMColour = fiftyMMaterial.color;
		hundredMColour = hundredMMaterial.color;
		hundredFiftyMColour = hundredFiftyMMaterial.color;
		noColour = noMaterialColour.color;
		aqaductsColour = aqaductsMaterial.color;

		smallestBuildings = new List<GameObject>();
		secondLargest = new List<GameObject>();
		tallestBuilding = new List<GameObject>();
		unColoured = new List<GameObject>();
		aquaduct = new List<GameObject>();

		for(int i=0; i< checkingIfBuilding.Length; i++)
		{
			tempPlacement = checkingIfBuilding[i].GetComponent<Renderer>().sharedMaterial;
	
			if(tempPlacement != null)
			{
				if(tempPlacement.color == fiftyMMaterial.color) 
				{
					smallestBuildings.Add (checkingIfBuilding[i].gameObject);
				}
				
				if(tempPlacement.color == hundredMMaterial.color) 
				{
					secondLargest.Add (checkingIfBuilding[i].gameObject);
				}
				
				if(tempPlacement.color == hundredFiftyMMaterial.color) 
				{
					tallestBuilding.Add (checkingIfBuilding[i].gameObject);
				}

				if(tempPlacement.color == noMaterialColour.color) 
				{
					unColoured.Add (checkingIfBuilding[i].gameObject);
				}
				
				if(tempPlacement.color == aqaductsMaterial.color) 
				{
					aquaduct.Add (checkingIfBuilding[i].gameObject);
				}

			}
		}
	}
	
}