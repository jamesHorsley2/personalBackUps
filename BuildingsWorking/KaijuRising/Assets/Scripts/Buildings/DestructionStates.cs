﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public enum BUILDING_STATE
{
	STATE_ZERO,
	STATE_ONE,
	STATE_TWO,
	STATE_THREE
};
public class DestructionStates : BuildingChange {
	
	private BUILDING_STATE currentState;

	[SyncVar]
	public int changeState;


	private void Start()
	{
		grabingBuildingInfo.onModifyHealth += activate;
		//grabingBuildingInfo.onModifyDeath();
	}


	private void activate()
	{
		//checkBuildingHealth();
		if(isServer)
		{
			intergerState(setHealthState(grabingBuildingInfo.health));
		}
		if(isClient)
		{
			intergerState(changeState);
			print ("working");
		}
	}

	private BUILDING_STATE intergerState(int stateChanger)
	{
		switch (stateChanger)
		{
			case 0: //This represents the State_Zero
				currentState = BUILDING_STATE.STATE_ZERO;
				changeTexture(stateChanger);
				print ("workingAyyyy");
				break;

			case 1:	//This represents the State_One
				currentState = BUILDING_STATE.STATE_ONE;
				changeTexture(stateChanger);
				break;

			case 2:	//This represents the State_Two
			currentState = BUILDING_STATE.STATE_TWO;
				changeTexture(stateChanger);
				break;

			case 3:	//This represents the State_Three
				currentState = BUILDING_STATE.STATE_THREE;
				changeTexture(stateChanger);
				break;
		}
		return currentState;
	}

	private int setHealthState(float health)
	{
		if(health > highest)
		{
			changeState = 0;
		}
		if(health <= highest)
		{
			changeState = 1;
		}
		if(health <= average)
		{
			changeState = 2;
		}
		if(health <= lowest)
		{
			changeState = 3;
		}
		return changeState;
	}

	public void changeTexture (int state)
	{
		updatedTexture(materialSelected[state]);
	}
}