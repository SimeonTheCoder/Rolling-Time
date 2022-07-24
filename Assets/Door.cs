using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorIndex;
    public PuzzleManager pManager;

    public Transform pos1;
    public Transform pos2;

    public int movementTime;
    private int time;

    private int stateLastTime;

    private bool timerStarted;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stateLastTime != pManager.states[doorIndex])
        {
            timerStarted = true;
        }

        if (timerStarted)
        {
            time++;

            Vector3 step = (pos2.position - pos1.position) / movementTime;

            if (pManager.states[doorIndex] == 1)
            {
                transform.position = step * time + pos1.position;
            }
            else
            {
                transform.position = pos2.position - step * time;
            }

            if (time == movementTime)
            {
                time = 0;
                timerStarted = false;
            }
        }

        stateLastTime = pManager.states[doorIndex];
    }
}
