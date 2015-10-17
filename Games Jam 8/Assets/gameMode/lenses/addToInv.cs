using UnityEngine;
using System.Collections;

public class addToInv : MonoBehaviour {
			
	private void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			addToInventory(col.gameObject);
			Destroy(gameObject);
		}
	}
	
	private void addToInventory(GameObject collidedObject)
	{
		allowUses increaseCounter = collidedObject.GetComponent<allowUses>();
		if(increaseCounter)
		{
			if(gameObject.tag == "RedLense")
			{
				//redCount = addLense(redCount);
				increaseCounter.redCount = increaseCounter.addLense(increaseCounter.redCount);
				//print(increaseCounter.addLense(increaseCounter.redCount));
			}
			
			if(gameObject.tag == "BlueLense")
			{
				increaseCounter.blueCount = increaseCounter.addLense(increaseCounter.blueCount);
				//print(increaseCounter.addLense(increaseCounter.blueCount));

			}
		}
	}
}
