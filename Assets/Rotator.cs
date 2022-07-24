using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public PuzzleManager pManager;
    public int id_l;
    public int id_r;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pManager.states[id_l] == 1)
        {
            transform.rotation *= Quaternion.Euler(0f, 0f, .4f);
        }else if(pManager.states[id_r] == 1)
        {
            transform.rotation *= Quaternion.Euler(0f, 0f, -.4f);
        }
    }
}
