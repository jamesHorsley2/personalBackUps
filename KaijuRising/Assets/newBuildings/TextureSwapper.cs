using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureSwapper : BuildingChange {
	
	public int amountInList;
	public Material[] modulMaterials;
	public List<List<Renderer>> ObjectCatagories;
	public string[] nameArray;

	private void Start()
	{	
		storeValues();
		searchBuilding();
		checkState();
	}

	private void checkState()
	{
		for(int i=0; i < amountInList;i++)
		{
			for(int q =0; q < ObjectCatagories[i].Count; q ++)
			{
				if(ObjectCatagories[i][q].name.Contains(nameArray[i]))
				{
					for(int b=0; b < ObjectCatagories[i].Count; b++)
					{
						updatedTexture(ObjectCatagories[i][b],modulMaterials[i]);
					}
				}
			}
		}
	}
	

	private void storeValues()
	{
		ObjectCatagories = new List<List<Renderer>>(amountInList);
		//creates the different sections to sort through the lists with
		for(int q =0; q < amountInList; q++)
		{
			ObjectCatagories.Add(new List<Renderer>());
		}
	}

	private void searchBuilding()
	{
		Renderer[] localMaterial = GetComponentsInChildren<Renderer>() as Renderer[];

		for(int z=0; z < amountInList; z++)
		{
			for(int i=0; i<localMaterial.Length; i++)
			{
				if(localMaterial[i].gameObject.name.Contains(nameArray[z]))
				{
					ObjectCatagories[z].Add(localMaterial[i]);
				}
			}
		}
	}

}
