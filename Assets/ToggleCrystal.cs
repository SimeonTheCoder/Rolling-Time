using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCrystal : MonoBehaviour
{
    public TimeCrystal timeCrystal;
    public bool active;
    public bool lastFrame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active != lastFrame && active)
        {
            timeCrystal.toggled = true;
        }

        lastFrame = active;
    }
}
