using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbingCamera : MonoBehaviour
{
    private float time;
    public int timeScale;
    public float bobbScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        transform.position += new Vector3(Mathf.Sin(time / (timeScale + .0f)) / (timeScale + .0f) / bobbScale, 0, 0);
    }
}
