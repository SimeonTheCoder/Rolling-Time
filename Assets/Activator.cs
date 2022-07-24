using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public int index;
    public PuzzleManager pManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        pManager.states[index] = 1;
    }

    public void Deactivate()
    {
        pManager.states[index] = 0;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Ouch!!!");

        Activate();
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        Deactivate();
    }
}
