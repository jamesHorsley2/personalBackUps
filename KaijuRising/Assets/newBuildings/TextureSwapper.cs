using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureSwapper : MonoBehaviour {
	
	public int amountInList;
	public List<List<Material>> ObjectCatagories;
	//public GameObject[][] ObjectCatagories;
	public string[] nameArray;
	public List<GameObject> storedMaterials;

	private void Start()
	{	
		storeValues();
		searchBuilding();
		print (ObjectCatagories[1][5]);
	}

	private void storeValues()
	{
		ObjectCatagories = new List<List<Material>>(amountInList);
		//creates the different sections to sort through the lists with
		for(int q =0; q < amountInList; q++)
		{
			ObjectCatagories.Add(new List<Material>());
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
	
					ObjectCatagories[z].Add(localMaterial[i].material);
					print (ObjectCatagories[z]);
					//ObjectCatagories[z][i] = localMaterial[i].gameObject;
					//storedMaterials.Add (localMaterial[i].gameObject);
	
				}
			}
		}
	}

}
