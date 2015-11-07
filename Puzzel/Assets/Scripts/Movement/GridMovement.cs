using UnityEngine;
using System.Collections;

public class GridMovement : MonoBehaviour {

	public string layerName;
	private RaycastHit checkAllowedMovement;
	private float maxDistance;
	private int layermask;
	private bool allowMovemnt = false;

	private void Start()
	{
		layermask = LayerMask.NameToLayer(layerName);
	}

	private void Update()
	{

	}

	private void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			checkCanMove();
		}
	}
	
	private void checkDirection()
	{

	}

	private void checkCanMove()
	{
		for(int i=0; i < 4; i++)
		{
			if(Physics.Raycast(transform.position + changeCheckDirection(i), -transform.up,out checkAllowedMovement, layermask))
			{
				Debug.DrawLine(transform.position + changeCheckDirection(i), new Vector3 (0,0,0),Color.red,5f);
				print("There is ground below");
			}
		}
	}

	private Vector3 changeCheckDirection(int dir)
	{
		Vector3 savedDir = new Vector3(0,0,0);
		switch(dir)
		{
			case 0:
				savedDir = transform.forward;
				break;
			case 1:
				savedDir = -transform.right;
				break;
			case 2:
				savedDir = -transform.forward;
				break;
			case 3:
				savedDir = transform.right;
				break;
		}
		return savedDir;
	}

}
