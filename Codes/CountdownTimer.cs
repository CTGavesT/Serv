using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float Timer;
    public float TimerLimit = 30.0f;
    public Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        Timer = TimerLimit;
        TimerText.text = "Timer Left: " + Timer.ToString("f0");
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime; //Timer = Timer - Time.deltaTime
        SetTimer();

        if (Timer <= 0.0f)
        {
            print("you lose!");
            Timer = TimerLimit;
        }
    }

    void SetTimer()
    {
        TimerText.text = "Timer Left: " + Timer.ToString("f0");
    }
}
