using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAudio : MonoBehaviour
{
    public GameObject[] triggers;
    public bool[] flags;

    // Start is called before the first frame update
    void Start()
    {
        flags = new bool[triggers.Length];

        for(int i=0; i<triggers.Length; i++)
        {
            flags[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<triggers.Length; i++)
        {
            if(triggers[i].GetComponent<AudioTrigger>().triggered && !flags[i])
            {
                triggers[i].GetComponent<AudioSource>().Play();
                flags[i] = true;

                for(int j=0; j<triggers.Length; j++)
                {
                    if(j != i)
                    {
                        triggers[j].GetComponent<AudioSource>().Stop();
                    }
                }
            }
        }
    }
}
