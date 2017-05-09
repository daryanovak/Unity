using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    public string FinishValue;
     public string minutes;
    public string seconds;

    void Start()
    {
        startTime = Time.time;
    }
    
    void Update()
    {
        float t = Time.time- startTime;
        minutes = ((int) t / 60).ToString();
        seconds = (t % 60).ToString("f0");

        timerText.text = minutes+":"+seconds;
       

    }
}
