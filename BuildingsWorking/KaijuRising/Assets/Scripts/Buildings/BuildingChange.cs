using UnityEngine;
using System.Collections;
public enum BUILDING_TYPE
{
	small,
	medium,
	large,
	aqaduct
};

[System.Serializable]
public struct buildingMeshs
{
	public Material[] smallest, average, largest, aqaductMesh;
}

public class BuildingChange : MonoBehaviour {
	[HideInInspector]
	public Material[] materialSelected;
	public string[] buildingTags;

	private BUILDING_TYPE differentBuilding;
	public int amountOfStates;
	public buildingMeshs newBuildingTexture;

	private void Start()
	{
		materialSelected = new Material[4];
		selector(findBuildingType(differentBuilding));
	}

	private void selector(BUILDING_TYPE findBuilding)
	{
		for(int i=0; i< amountOfStates; i++)
		{
			switch (findBuilding)
			{
			case BUILDING_TYPE.small:
				materialSelected[i] = newBuildingTexture.smallest[i];
				break;
			case BUILDING_TYPE.medium:
				materialSelected[i] = newBuildingTexture.average[i];
				break;
			case BUILDING_TYPE.large:
				materialSelected[i] = newBuildingTexture.largest[i];
				break;
			case BUILDING_TYPE.aqaduct:
				materialSelected[i] = newBuildingTexture.aqaductMesh[i];
				break;
			}
		}
	}
	
	private BUILDING_TYPE findBuildingType(BUILDING_TYPE buildingChanged)
	{
		if(gameObject.tag == buildingTags[0])
		{
			return BUILDING_TYPE.small;
		}
		if(gameObject.tag == buildingTags[1])
		{
			return BUILDING_TYPE.medium;
		}
		if(gameObject.tag == buildingTags[2])
		{
			return BUILDING_TYPE.large;
		}
		if(gameObject.tag == buildingTags[3])
		{
			return BUILDING_TYPE.aqaduct;
		}
		return buildingChanged;
	}

	public void updatedTexture(Material newTexture) // this is called in 'Destruction States'
	{
		GetComponent<Renderer>().material = newTexture;
	}
}
