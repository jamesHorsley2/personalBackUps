using UnityEngine;
using System.Collections;

public class FirstPersonHead : MonoBehaviour
{
	public int ySensitivity; //The speed at which the players head rotation is accelerated at.

	private void Update()
	{
		lockAxis();
		rotate();
	}

	private void rotate() //Rotates the characters head when the mouse is moved.
	{
		float y = Input.GetAxis("Mouse Y");
		transform.Rotate(new Vector3(y * -ySensitivity, 0, 0));
	}

	private void lockAxis() //Locks the X and Y axis to 0.
	{
		gameObject.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
	}
}