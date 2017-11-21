using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBounceScript : MonoBehaviour {
	
	private float deltaTime = 0;
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale >0f)
		this.transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Cos (deltaTime -= Time.deltaTime)/250);

	}
}
