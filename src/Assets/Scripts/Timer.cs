using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float myTimer = 5, TimerAfter = 5;
    private Text timerText;
    public GameObject TimesUp;

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        myTimer -= Time.deltaTime;
        timerText.text = "Time: " + myTimer.ToString("f0");

        if (Input.GetKey(KeyCode.R))
        {
            myTimer = 0;
            TimesUp.SetActive(true);
            timerText.text = "";
            TimerAfter -= Time.deltaTime;
            if (TimerAfter < 0)
            {
                SceneManager.LoadScene("Main");
            }
        }

        if (myTimer < 0)
        {
            TimesUp.SetActive(true);
            timerText.text = "";
            TimerAfter -= Time.deltaTime;
            if (TimerAfter < 0)
            {
                SceneManager.LoadScene("Main");
            }
        }

        print(timerText);
    }
}
