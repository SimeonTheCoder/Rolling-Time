using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    private float time;
    public float timeScale;
    public int waveScale;
    
    private float desired;
    private bool timerStarted;
    private int correctionTime;
    private float originalProblem;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        desired = timeScale;
        timerStarted = false;
        correctionTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeScale != desired && !timerStarted)
        {
            timerStarted = true;
            originalProblem = timeScale;
        }

        if(timerStarted)
        {
            correctionTime++;

            float step = (desired - originalProblem) / 2500f;

            timeScale = originalProblem + step * correctionTime;

            if (correctionTime == 2500)
            {
                timerStarted = false;
                timeScale = desired;
                correctionTime = 0;
            }
        }

        time++;

        transform.rotation *= Quaternion.Euler(0, 0, Mathf.Sin(time / (timeScale + .0f)) / (timeScale + .0f) * waveScale);
    }
}
