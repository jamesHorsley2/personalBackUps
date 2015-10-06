using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class addStuffToBuildings : MonoBehaviour {

	public bool run;
	public DestroyBuilding[] checkingIfBuilding;

	private void Update()
	{
		if(run)
		checkAllBuildings();
	}

	private void checkAllBuildings()
	{
		checkingIfBuilding = GameObject.FindObjectsOfType<DestroyBuilding>() as DestroyBuilding[];
		for(int i=0; i< checkingIfBuilding.Length; i++)
		{
			print ("i am currently a building");
			//checkingIfBuilding[i].gameObject.AddComponent<Entity>();
		}
	}
	
}

