using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	public int levelTime;
	public int numberOfPapers;
	public Canvas canvas;
	public Text winText, loseText;
	public string nextSceneToLoad;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("wintext") != null){
		winText = GameObject.FindGameObjectWithTag ("wintext").GetComponent<Text>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > levelTime)
			Debug.Log ("Game over, no more time");
	}

	public void GameOver(string nextScene){
		Debug.Log ("You won!");
		winText.text = "You won!";
		StartCoroutine (LoadNextScene (nextScene));


	}

	public void LoseCondition(){
		loseText.text = "GAME OVER!";
		Time.timeScale = 0.001f;
		StartCoroutine ("wait5");
		Time.timeScale = 1f;
		LoadNextScene ("Menu");

	}

	IEnumerator wait5() {
		yield return new WaitForSecondsRealtime (5);
	}

	IEnumerator LoadNextScene(string nextScene){
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene (nextScene);
	}


	public void AllPapersCollected(int numPapers){
		if (numPapers == numberOfPapers) {
			GameOver (nextSceneToLoad);
		}
	}


}
