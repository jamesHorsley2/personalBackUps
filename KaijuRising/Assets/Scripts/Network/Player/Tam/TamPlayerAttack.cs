﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TamPlayerAttack : NetworkBehaviour 
{
	public string[] tags;
	public float attackRadius;
	public GameObject attackCenter;
	public KeyCode attackKey;
	public float attackDamage;
	//private PlayerAnimations playAnim;
	private TamPlayerScore playerScore;
	
	[Command]
	private void Cmd_detectObjects(Vector3 center, GameObject player)
	{
		Collider[] colliders = Physics.OverlapSphere(center, attackRadius);
		for(int i=0; i<colliders.Length; i++)
		{
			if(colliders != null)
			{
				for(int z=0; z< tags.Length; z++)
				{
					if(colliders[i].gameObject.tag == tags[z])
					{
						dealDamageTowardsBuildings(colliders[i].gameObject);
					}
					if (colliders[i].gameObject != gameObject && colliders[i].gameObject.tag == "Player")
					{
						colliders[i].gameObject.GetComponent<TamPlayerHealth>().modifyHealth(-attackDamage, GetComponent<TamPlayerScore>().getPlayerNumber());
					}
				}
			}
		}
	}
	
	void Update()
	{
		if (!isLocalPlayer)
			return;
		
		if (Input.GetKeyDown(attackKey))
		{
			//playAnim.playAttack();
			Cmd_detectObjects(attackCenter.transform.position, gameObject);
		}
	}
	
	private void Start()
	{
		playerScore = GetComponent<TamPlayerScore>();
		//playAnim = GetComponent<PlayerAnimations>();
	}

	private void dealDamageTowardsBuildings(GameObject collidedObject)
	{
		Entity building = collidedObject.GetComponent<Entity>();
		if(building)
		{
			building.takeDamage(attackDamage);
			building = null;
		}
	}
}