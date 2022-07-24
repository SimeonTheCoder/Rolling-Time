using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public GameObject player;
    public float treshold;

    public GameObject secondaryGlow;

    public bool isDragged;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        isDragged = false;

        offset = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDragged)
        {
            float dx = Mathf.Abs(transform.position.x - player.transform.position.x);
            float dy = Mathf.Abs(transform.position.y - player.transform.position.y);

            float distance = Mathf.Sqrt(dx * dx + dy * dy);

            if (distance > treshold + 2f)
            {
                secondaryGlow.SetActive(false);

                isDragged = false;

                transform.parent = null;
            }
        }

        if(Input.GetKeyDown("e"))
        {
            if(isDragged)
            {
                secondaryGlow.SetActive(false);

                isDragged = false;

                offset = new Vector3(0, 0, 0);

                transform.parent = null;
            }
            else
            {
                float dx = Mathf.Abs(transform.position.x - player.transform.position.x);
                float dy = Mathf.Abs(transform.position.y - player.transform.position.y);

                float distance = Mathf.Sqrt(dx * dx + dy * dy);

                if(distance < treshold)
                {
                    secondaryGlow.SetActive(true);

                    isDragged = true;

                    transform.parent = player.transform;
                }
            }
        }
    }
}
