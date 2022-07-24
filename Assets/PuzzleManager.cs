using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int[] states;
    public int maxSize;

    // Start is called before the first frame update
    void Start()
    {
        states = new int[maxSize];

        for(int i=0; i<maxSize; i++)
        {
            states[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
