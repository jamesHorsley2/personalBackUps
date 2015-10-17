// Written By Nelson Burge

using UnityEngine;
using System.Collections;

public class FirstPersonBody : MonoBehaviour
{
	public int xSensitivity; //The speed at which the players rotation is accelerated at

	void Update()
	{
		rotate();
	}

	private void rotate() //Rotates the character in the direction the mouse is being moved by multiplied by a user set sensitivity
	{
		float y = Input.GetAxis("Mouse X");
		transform.Rotate(new Vector3(0, y * xSensitivity, 0));
	}
}