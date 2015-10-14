using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Entity : DamageableEntity {

    private void debugControls()
    {
        if(Input.GetKeyDown(KeyCode.Minus))
        {
            Cmd_takeDamage(1);
        }
        else if(Input.GetKeyDown(KeyCode.Equals))
        {
            heal(1);
        }
	}
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        debugControls();
    }

    protected void onTakeDamage()
    {
        print("Play Take Damage Animation!");
        //Modify GUI health Bar!
        //Anything else we might need?
    }

    protected void onHeal()
    {
        print("Healing kaiju!");
        //Modify GUI health Bar!
        //Anything else we might need?
    }

    public void heal(float amount)
    {
        amount = Mathf.Abs(amount); //Absolute value of something means positive
        //We know we are healing, so we should assign an 'onHeal' function to 'onModifyHealth'
        onModifyHealth = onHeal;
        Cmd_modifyHealth(amount);
    }
	[Command]
    public void Cmd_takeDamage(float amount)
    {
		Rpc_activateDamager(amount);
    }
	[ClientRpc]
	private void Rpc_activateDamager(float amount)
	{
		amount = Mathf.Abs(amount) * -1; //Make it positive and then flip it
		//We know we are damaged, so we should assign an 'onTakeDamage' function to 'onModifyHealth'
		onModifyHealth += onTakeDamage;
		Cmd_modifyHealth(amount);
	}
	
}
