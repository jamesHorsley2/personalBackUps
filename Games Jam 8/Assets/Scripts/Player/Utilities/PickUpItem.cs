using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour
{
	public string target;
	public CreateGoal createGoal;
	public LayerMask rayHitLayer;
	public PickedUpItems pickedUpItems;

	private void Start()
	{
		target = createGoal.assignTarget();
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible(false);
		//Cursor.visible = true;
	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			castRay(2f);
		}
	}
	
	private void castRay(float length)
	{
		RaycastHit rayHit;
		if (Physics.Raycast((transform.position), transform.forward, out rayHit, length, rayHitLayer))
		{
			onRaycastHit(rayHit.collider);
		}
	}

	public void onRaycastHit(Collider collidedObject)
	{
		if(collidedObject.gameObject.name == target && collidedObject.gameObject.tag == "CollectibleItem")
		{
			Destroy(collidedObject.gameObject);
			target = createGoal.assignTarget();
			pickedUpItems.pickedUpItems++;
		}
	}
}