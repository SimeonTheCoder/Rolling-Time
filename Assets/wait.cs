using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wait : MonoBehaviour
{
    public GameObject exit;
    public int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        if(time == 1000)
        {
            exit.GetComponent<LevelExit>().call();
        }
    }
}
