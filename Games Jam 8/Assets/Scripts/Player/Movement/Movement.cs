using UnityEngine;
using System.Collections;

[System.Serializable]
public struct DirectionalSpeeds
{
	public float strafe;
	public float forward;
	public float back;
	public float sprint;
}

[System.Serializable]
public struct DirectionalKeys
{
	public KeyCode left;
	public KeyCode right;
	public KeyCode forward;
	public KeyCode back;
	public KeyCode sprint;
}

public class Movement : MonoBehaviour
{
	public DirectionalKeys directionalKeys;
	public DirectionalSpeeds directionalSpeeds;
	Rigidbody myRb;
	
	void Start()
	{
		myRb = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		movement(-transform.right, directionalKeys.left, directionalSpeeds.strafe);
		movement(transform.right, directionalKeys.right, directionalSpeeds.strafe);
		movement(transform.forward, directionalKeys.forward, directionalSpeeds.forward);
		movement(-transform.forward, directionalKeys.back, directionalSpeeds.back);
	}
	
	public void movement(Vector3 direction, KeyCode input,   float speed)
	{
		float sprintTemp;
	
		if(Input.GetKey(directionalKeys.sprint))
		{
			sprintTemp = directionalSpeeds.sprint;
		}
		else
		{
			sprintTemp = 1f;
		}
	
		if(Input.GetKey
		   (input))
		{
			myRb.MovePosition(myRb.position + direction.normalized * speed * sprintTemp * Time.deltaTime);
			//gameObject.transform.Translate(direction * speed * Time.deltaTime);
		}
	}
}