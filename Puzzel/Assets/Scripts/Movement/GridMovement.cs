using UnityEngine;
using System.Collections;

public class GridMovement : MonoBehaviour {

	private RaycastHit checkAllowedMovement;
	private int layermask;
	private bool allowMovemnt = false;
	private bool[] canMove = new bool[4], controls = new bool[4];
	//private Rigidbody rb;


	public float maxDistance, speed;
	public string layerName;

	private void Start()
	{
		layermask = LayerMask.NameToLayer(layerName);
	//	rb = GetComponent<Rigidbody>();
		checkCanMove();
	}


	private void Update()
	{
		controls[0] = Input.GetKey(KeyCode.UpArrow);
		controls[1] = Input.GetKey(KeyCode.LeftArrow);
		controls[2] = Input.GetKey(KeyCode.DownArrow);
		controls[3] = Input.GetKey(KeyCode.RightArrow);


		if(controls[0] && canMove[0])
		{
			movement(transform.forward, speed);
		}
		else if(controls[1] && canMove[1])
		{
			movement(-transform.right, speed);
		}
		else if(controls[2] && canMove[2])
		{
			movement(-transform.forward, speed);
		}
		else if(controls[3] && canMove[3])
		{
			movement(transform.right, speed);	
		}
	}
	

	private Vector3 changeCheckDirection(int dir)
	{
		Vector3 savedDir = new Vector3(0,0,0);
		switch(dir)
		{
			case 0:
				savedDir = transform.forward;
				//savedDir = Vector3.forward;
				break;
			case 1:
				savedDir = -transform.right;
				//savedDir = Vector3.left;
				break;
			case 2:
				savedDir = -transform.forward;
				//savedDir = Vector3.back;
				break;
			case 3:
				savedDir = transform.right;
				//savedDir = Vector3.right;
				break;
		}
		return savedDir;
	}

	private void checkCanMove()
	{
		for(int i=0; i < 4; i++)
		{
			if(Physics.Raycast(transform.position + changeCheckDirection(i), -transform.up,out checkAllowedMovement, layermask))
			{
				canMove[i] = true;
				//Debug.DrawLine(transform.position + changeCheckDirection(i), new Vector3 (0,0,0),Color.red,5f);
			}
			else
			{
				canMove[i] = false;
			}
		}
	}

	private void movement(Vector3 direction, float speed)
	{
		//rb.velocity = direction * speed;
		//rb.AddForce(direction * speed);
		transform.Translate(direction * Time.deltaTime * speed);
		checkCanMove();
	}
}
