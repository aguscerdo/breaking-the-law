using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void LoadScene(string SceneName){
		if (SceneName == "Quit") {
			Application.Quit ();
		}
		Debug.Log ("Trying to load " + SceneName);
		SceneManager.LoadScene (SceneName);
	}
}
