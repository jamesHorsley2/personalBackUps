using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(attackType),(typeof(KaijuMover)))]
public abstract class KaijuController : NetworkBehaviour {

    public KaijuAnimator kaijuAnims;
    public KaijuMover kaijuMover;
	public attackType attackSet;
	public float primaryAttackSpeed, specialAttackSpeed;

	public delegate void attackCondition();
	public static event attackCondition specialKaijuType;

	void Awake()
	{
		attackSet = GetComponent<attackType>();
		kaijuMover = GetComponent<KaijuMover>();
		kaijuAnims = GetComponentInChildren<KaijuAnimator>();
		attackSet.attackStates = ATTACK_STATE.IS_NOT_ATTACKING;
	}

    protected void stopWalkFunction()
    {
        kaijuAnims.setWalkState(false);
    }

    protected void walkFunction(Vector3 direction)
    {
        //make the kaiju walk (move)
        kaijuMover.walk(direction);
        //make the kaiju animate walking (anims)
        kaijuAnims.setWalkState(true);
    }

    public void primaryAttackFunction()
    {
        if (!kaijuAnims.isAttacking())
        {
            //toggle any damage affectors (don't have any yet)
			//make the kaiju animate primary attack (anims)
			StartCoroutine(setState(ATTACK_STATE.IS_ATTACKING, primaryAttackSpeed));
			kaijuAnims.playAttack();
        }
    }

    public void specialAttackFunction()
    {
        if(!kaijuAnims.isAttacking())
        {
            //toggle any damage affectors (don't have any yet)
            //make the kaiju animate special attack (anims)
			StartCoroutine(setState(ATTACK_STATE.IS_SPECIAL_ATTACKING, specialAttackSpeed));
            kaijuAnims.playSpecialAttack();
        }
    }

    protected void turnFunction(int direction)
    {
        //make the kaiju turn (rotate)
        kaijuMover.turn(direction);
        //make the kaiju animate turn?/walk (anims)
        kaijuAnims.setWalkState(true);
    }

	private IEnumerator setState(ATTACK_STATE newState, float speed)
	{
		attackSet.attackStates = newState;
		yield return new WaitForSeconds (speed);
		attackSet.attackStates = ATTACK_STATE.IS_NOT_ATTACKING;
	}

}
