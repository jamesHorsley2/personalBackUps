using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EndCondition : MonoBehaviour {

	public float timer;
	public GameObject canvas;


	private void Start()
	{
		StartCoroutine(gameTimer());
	}



	private IEnumerator gameTimer()
	{
		while (timer > 0f)
		{
			timer -= Time.deltaTime;
			yield return null;
		}
		endCondition();
	}




	private void endCondition()
	{
		canvas.SetActive(true);
		Time.timeScale = 0f;
		//place ending condition
	}

}
