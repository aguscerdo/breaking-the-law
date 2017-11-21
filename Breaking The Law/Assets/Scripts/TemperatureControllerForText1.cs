using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureControllerForText1 : MonoBehaviour {

    public float myTemp = 25;
    private Text tempText;
  

    void Start()
    {
        tempText = GetComponent<Text>();

    }

    void Update()
    {
        myTemp -= 2 * Time.deltaTime;
        tempText.text = "Temperature: " + myTemp.ToString("f0");
        print(myTemp);
    }
}
