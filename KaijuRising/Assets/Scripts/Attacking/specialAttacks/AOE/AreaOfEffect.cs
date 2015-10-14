using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AreaOfEffect : NetworkBehaviour {

	public float damageValue, radius;
	public string[] tags;
	
	private void Start()
	{
		transform.localScale = new Vector3(radius,1f,radius);
		if(isLocalPlayer && !isServer)
		{
			Cmd_activateAttack();
		}
		else if(isServer)
		{
			//Cmd_dealDamage();
			//activateAttack();
			NetworkServer.Destroy(gameObject);
		}
	}
	private void Cmd_activateAttack()
	{
		storePlayers(transform.position, radius);
		NetworkServer.Destroy(gameObject);
	}

	private void activateAttack()
	{
		storePlayers(transform.position, radius);
		NetworkServer.Destroy(gameObject);
	}


	private void storePlayers(Vector3 center, float radius) 
	{
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		for(int i=0; i<hitColliders.Length; i++)
		{
			if(hitColliders != null)
			{
				for(int z=0; z< tags.Length; z++)
				{
					if(hitColliders[i].gameObject.tag == tags[z])
					{
						Cmd_dealDamage(hitColliders[i].gameObject);
					}
				}
			}
		}
	}
	private void Cmd_dealDamage(GameObject collidedObject)
	{
		Entity kaiju = collidedObject.GetComponent<Entity>();
		if(kaiju)
		{
			kaiju.Cmd_takeDamage(damageValue);
			kaiju = null;
		}
	}
}
