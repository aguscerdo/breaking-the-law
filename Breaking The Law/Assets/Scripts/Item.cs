using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public string i_tag;

	// Use this for initialization
	void Start () {
		this.gameObject.tag = i_tag;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Hello world");
		if (other.gameObject.CompareTag("Player")) {
			this.gameObject.SetActive(false);

			if (this.CompareTag("gravity")) 
				other.gameObject.GetComponent<PlayerController>().gravity_count += 1;
			
		};
	}
}