using UnityEngine;
using System.Collections;

public class KaijuMover : AbstractMover {
	
    public void walk(Vector3 direction)
    {
        move(direction, speed);
    }

    public void walk(float multiplier) //increase movement speed
    {
        move(transform.forward, speed * multiplier);
    }

    public void turn(int direction)
    {
        transform.Rotate(transform.up, direction * speed * Time.deltaTime);
    }

    public void turn(int direction, float multiplier)
    {
        transform.Rotate(transform.up, direction * speed * multiplier * Time.deltaTime);
    }

	// Update is called once per frame
	void FixedUpdate () {
        //debugControls();
	}
}
