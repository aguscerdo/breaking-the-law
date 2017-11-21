using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureControllerForPlayer : MonoBehaviour {

    private Rigidbody2D rb;
    public float myTemp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float OriTemp = myTemp;
        myTemp -= 2 * Time.deltaTime;

        if (myTemp < OriTemp)
        {
            rb.velocity = (new Vector2(rb.velocity.x * myTemp / OriTemp, rb.velocity.y));
        }
    }

}
