using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public abstract class AbstractAnimator : NetworkBehaviour {

    public Animator anim;

	protected void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}

	protected void setAnimParameter(string paramName, bool state)
    {
        anim.SetBool(paramName, state);
    }

    protected void setTimedAnimParameter(string animParam, float seconds, bool state)
    {
        StartCoroutine( startTimedAnim(animParam, seconds, state) );
    }

    private IEnumerator startTimedAnim(string animParam, float seconds, bool state)
    {
        setAnimParameter(animParam, state);
        //wait
        float time = seconds;
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null; //wait for a frame
        }
        //flip the state back
        setAnimParameter(animParam, !state);
    }
}
