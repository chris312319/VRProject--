using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    float timer_f = 0f;
    int timer_i = 0;
    static public int minute = 0;
    static public int second = 0;
    static public bool timestart = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(timestart)timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        turn_time();

        if (minute < 10)
        {
            if (second < 10)
            {
                GetComponent<Text>().text = "0" + minute + ":0" + second;
            }
            else
            {
                GetComponent<Text>().text = "0" + minute + ":" + second;
            }


        }
        else
        {
            if(second < 10)
            {
                GetComponent<Text>().text = "0" + minute + ":0" + second;
            }
            else
            {
                GetComponent<Text>().text =  minute + ":" + second;
            }
        }
    }

    void turn_time()
    {
        minute = timer_i / 60;
        second = timer_i % 60;
    }
}
