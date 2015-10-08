using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class JoystickMovement : KaijuController {

	/*
	 * This script goes onto the player, it checks the virtual joystick input & moves accordingly.
	 */ 
	public KaijuAnimator playerAnimations;
	//public AbstractPlayerAnimations playerAnimations;
//	private Rigidbody rb;
	public bool isInputReceived;
	public Vector3 joystickDirection; // The direction from the joystick origin to the joystick.
	public Transform playerCamera; // The actual camera.
	public Transform untiltedPlayerCamera; // An object that represents the camera's y rotation only. 
										   //Used to convert virtual joystick movement to the player based on how the camera has rotated around the player
										// You should make an empty game object and call it camera Y as an example, and then assign it to the variable.
	public Transform joystick; // The movable joystick
	public Transform joystickOrigin; // Where the joystick is when it's not in use.
	
	private void Update()
	{
		disableInput();
	}

	private void Start()
	{
		playerAnimations = GetComponentInChildren<KaijuAnimator>();
	}

	private void FixedUpdate()
	{
		if(!isLocalPlayer)
			return;

		joystickInput();
	}

	private void joystickInput()
	{
		if(isInputReceived == true)
		{
			joystick.transform.position = Input.mousePosition;
			joystick.position = joystickOrigin.position + Vector3.ClampMagnitude((joystick.position - joystickOrigin.position), 20f); // Restricts joystick to circle
			joystickDirection = (joystick.position - joystickOrigin.position); // Direction to work out which direction the player will move in.
			joystickDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y); // Converts an XY Vector to an XZ Vector.
			untiltedPlayerCamera.rotation = Quaternion.Euler(new Vector3(0,playerCamera.eulerAngles.y,0)); // Set Y rotation to actual camera's Y rotation.
			joystickDirection = untiltedPlayerCamera.TransformDirection(joystickDirection); // This is where we convert the direction by considering the direction the camera is facing.
	
			transform.LookAt (joystickDirection + transform.position);
	
			walkFunction(joystickDirection);
		}
		else
		{
			stopWalkFunction();
		}
	}

	public void movement(Vector3 newJoyStickDirection)
	{
		transform.LookAt (newJoyStickDirection + transform.position);
	}

	public void enableInput()
	{
		isInputReceived = true;
	}

	private void disableInput()
	{
		if(Input.GetMouseButtonUp(0))
		{
			isInputReceived = false;
			joystick.position = joystickOrigin.position;
		}
	}
}