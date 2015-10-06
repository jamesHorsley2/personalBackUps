using UnityEngine;
using System.Collections;

[System.Serializable]
public struct KaijuKeybinds
{
    public KeyCode walkKey, leftTurnKey, rightTurnKey, 
        primaryAttackKey, specialAttackKey;
}

public enum MOVEMENT_CHANGE
{
	NORMAL_MOVEMENT,
	SPECIAL_MOVEMENT
};

public class KeyboardKaijuController : KaijuController 
{
    public KaijuKeybinds controls;
	public delegate void currentControls();
	public static event currentControls changeControls;
	public MOVEMENT_CHANGE changeMovement;
	

    private void checkControls()
    {
        if(Input.GetKey(controls.walkKey))
        {
            walkFunction(transform.forward);
        }
        else
        {
            stopWalkFunction();
        }
        if (Input.GetKeyDown(controls.primaryAttackKey))
        {
			attackSet.attackStates = ATTACK_STATE.IS_ATTACKING;
            primaryAttackFunction();
        }
		else
		{
			attackSet.attackStates = ATTACK_STATE.IS_NOT_ATTACKING;
		}
        if (Input.GetKeyDown(controls.specialAttackKey))
        {
			attackSet.attackStates = ATTACK_STATE.IS_SPECIAL_ATTACKING;
            specialAttackFunction();
        }
		else
		{
			attackSet.attackStates = ATTACK_STATE.IS_NOT_ATTACKING;
		}
        if (Input.GetKey(controls.leftTurnKey))
        {
            turnFunction(-1);
        }
        else if (Input.GetKey(controls.rightTurnKey))
        {
            turnFunction(1);
        }
    }

	private void changeMovementState()
	{
		//disables movement besides turning
		if (Input.GetKey(controls.leftTurnKey))
		{
			turnFunction(-1);
		}
		else if (Input.GetKey(controls.rightTurnKey))
		{
			turnFunction(1);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		switch(changeMovement)
		{
			case MOVEMENT_CHANGE.NORMAL_MOVEMENT:
				changeControls = checkControls;
				break;
			case MOVEMENT_CHANGE.SPECIAL_MOVEMENT: 
				changeControls = changeMovementState;
				//changeControls();
				break;
		}
		changeControls();
	}
}
