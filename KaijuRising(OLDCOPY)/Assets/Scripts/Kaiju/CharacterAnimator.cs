using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour {

    public Animator anim; //The animator component of the character

    private void debugControls() //placeholder inputs to test anims
    {
        bool isAttacking = false;

        //we want to see if we have attacked at all
        // 'something' | 'something' means if either of them are true, return true
        isAttacking = anim.GetBool("Primary") | anim.GetBool("Special");

        if(Input.GetKey(KeyCode.W))
        {
            //play walking animation
            playWalk();
        }
        else
        {
            //stop walking animation
            stopWalk();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //play primary attack - start coroutine to monitor time of animation
            //playPrimary();
            if(!isAttacking)
                StartCoroutine(playPrimary());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //play primary attack - start coroutine to monitor time of animation
            //playPrimary();
            if (!isAttacking)
                StartCoroutine(playSpecial());
        }
    }

    public void playWalk()
    {
        anim.SetBool("Walking", true);
    }

    public void stopWalk()
    {
        anim.SetBool("Walking", false);
    }

    public IEnumerator playSpecial()
    {
        anim.SetBool("Special", true);
        yield return new WaitForSeconds(0.6f);
        stopSpecial();
    }

    public IEnumerator playPrimary()
    {
        anim.SetBool("Primary", true);
        yield return new WaitForSeconds(0.3f);
        stopPrimary();
    }

    public void stopPrimary()
    {
        anim.SetBool("Primary", false);
    }

    public void stopSpecial()
    {
        anim.SetBool("Special", false);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        debugControls();
	}
}
