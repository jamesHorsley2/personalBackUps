using UnityEngine;
using System.Collections;

[System.Serializable]
public struct TimedAnimation
{
    public string animationParameter;
    public float duration;
}

public class KaijuAnimator : AbstractAnimator {

    //public AnimationClip idleAnim, walkingAnim, specialAnim, primaryAnim;
    public TimedAnimation special, primary;

    //protected void Start()
    //{
    //    AnimatorOverrideController overrideCont = new AnimatorOverrideController();
    //    RuntimeAnimatorController animCont = new RuntimeAnimatorController();
        
    //    overrideCont.runtimeAnimatorController = anim.runtimeAnimatorController;
    //    overrideCont["Gozu_Idle"] = idleAnim;
    //    overrideCont["Gozu_Walk"] = walkingAnim;
    //    overrideCont["Gozu_Primary"] = primaryAnim;
    //    overrideCont["Gozu_Special"] = specialAnim;
    //    overrideCont.name = gameObject.name;
    //    anim.runtimeAnimatorController = overrideCont;
    //    //foreach(AnimationClip clip in overrideCont.runtimeAnimatorController.animationClips)
    //    //{
    //    //    print(clip.name);
    //    //}
    //}

    public bool isAttacking()
    {
        return anim.GetBool(primary.animationParameter) | anim.GetBool(special.animationParameter);
    }

    private void debugControls() //function to test animations in class
    {
        bool isAttacking = false;

        //we want to see if we have attacked at all
        // 'something' | 'something' means if either of them are true, return true
        isAttacking = anim.GetBool(primary.animationParameter) | 
                        anim.GetBool(special.animationParameter);

        if (Input.GetKey(KeyCode.W))
        {
            //play walking animation
            setWalkState(true);
        }
        else
        {
            setWalkState(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //play primary attack - start coroutine to monitor time of animation
            //playPrimary();
            if (!isAttacking)
                playAttack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //play primary attack - start coroutine to monitor time of animation
            //playPrimary();
            if (!isAttacking)
                playSpecialAttack();
        }
    }

    public void setWalkState(bool state)
    {
        setAnimParameter("Walking", state);
    }

    public void playSpecialAttack()
    {
        setTimedAnimParameter(special.animationParameter, special.duration, true);
    }

    public void playAttack()
    {
        setTimedAnimParameter(primary.animationParameter, primary.duration, true);
    }

    public void playIdle()
    {
        setAnimParameter(primary.animationParameter, false);
        setAnimParameter(special.animationParameter, false);
        setAnimParameter("Walking", false);
    }

	// Update is called once per frame
	void LateUpdate () {
        //debugControls();
	}
}
