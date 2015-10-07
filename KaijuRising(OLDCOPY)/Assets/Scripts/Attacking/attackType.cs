using UnityEngine;
using System.Collections;
public enum ATTACK_STATE
{
	IS_ATTACKING,
	IS_SPECIAL_ATTACKING,
	IS_NOT_ATTACKING
};
public class attackType : MonoBehaviour 
{
	public float primaryDamage = 25f, specialDamage = 100f;
	public ATTACK_STATE attackStates;
	public Entity kaijuState;

	private void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			currentAttackState(col.gameObject);
		}
	}


	// the states are changed in the kaiju controller script, with joystick movement inherirt from
	// if you have any issuse ask me
	
	public void currentAttackState(GameObject collidedObject)
	{
		switch (attackStates)
		{
			case ATTACK_STATE.IS_ATTACKING:
			StartCoroutine(primaryAttack(collidedObject));
				break;

			case ATTACK_STATE.IS_SPECIAL_ATTACKING:
			StartCoroutine(specialAttack(collidedObject));
				break;

			case ATTACK_STATE.IS_NOT_ATTACKING:
				kaijuState = null;
			StopAllCoroutines();
				break;

			default:
				attackStates = ATTACK_STATE.IS_NOT_ATTACKING;
				//kaijuState = null;
				break;
		}
	}

	public IEnumerator primaryAttack(GameObject collidedObject)
	{
		kaijuState = collidedObject.GetComponent<Entity>();
		if(kaijuState)
		{
			yield return new WaitForSeconds(1f);
			kaijuState.takeDamage(primaryDamage);
		}
	}

	public IEnumerator specialAttack(GameObject collidedObject)
	{
		kaijuState = collidedObject.GetComponent<Entity>();
		if(kaijuState)
		{
			yield return new WaitForSeconds(1f);
			kaijuState.takeDamage(specialDamage);
		}
	}
}
