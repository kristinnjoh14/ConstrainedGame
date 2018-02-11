using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    public Text timerText;
    private float startTime;

	// Use this for initialization
	void Start ()
	{
	    startTime = 60.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float t = startTime - Time.time;

	   // string minutes = ((int) t / 60).ToString();
	    string seconds = (t % 60).ToString("f1");

	    timerText.text = seconds;
	}
}
