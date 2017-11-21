using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer1 : MonoBehaviour {

	public Text timerText;
	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - startTime;
		string seconds = t.ToString ("f0");

		timerText.text = seconds;

	}
}
