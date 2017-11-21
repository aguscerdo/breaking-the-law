using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordMover : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector2 (transform.position.x, transform.position.y + (float)(Time.deltaTime/1.2));

		if (Time.timeSinceLevelLoad > 51) {
			SceneManager.LoadScene ("Tutorial1");
		}
	}
}
