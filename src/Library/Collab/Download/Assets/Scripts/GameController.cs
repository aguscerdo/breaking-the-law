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
	private int GameOverTime=0;
	private bool gameOver;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("wintext") != null){
		winText = GameObject.FindGameObjectWithTag ("wintext").GetComponent<Text>();
		}
		gameOver = false;
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

	/*void FixedUpdate(){
		if (GameOverTime < 1000 && GameOver) {
			GameOverTime++;
		} else
			SceneManager.LoadScene ("Menu");
	}*/

	public void LoseCondition(){
		loseText.text = "GAME OVER!";
		StartCoroutine( LoadNextScene ("Menu"));
		Time.timeScale = 0f;
	}


	IEnumerator LoadNextScene(string nextScene){
		yield return new WaitForSecondsRealtime (4);
		SceneManager.LoadScene (nextScene);
	}


	public void AllPapersCollected(int numPapers){
		if (numPapers == numberOfPapers) {
			GameOver (nextSceneToLoad);
		}
	}


}
