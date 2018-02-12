using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public float startTime;
    public float t;
    private float countdown;

    // Use this for initialization
    void Start()
    {
        t = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (t > 0)
        {
            t -= Time.deltaTime;
        }
        else if (t < 0)
        {
            t = startTime;
        }
        timerText.text = t.ToString("f1");

    }
}