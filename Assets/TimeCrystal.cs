using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCrystal : MonoBehaviour
{
    public GameObject camera;

    public GameObject[] lights;

    public bool toggled;

    public ParticleSystem particleSystem;
    public GameObject secondaryGlow;
    public GameObject flare;
    public GameObject saveGlow;

    private List<Vector3> pos;
    private int posIndex;
    private Vector3 origin;

    private int time;
    private bool timerStarted;
    private bool isReset;
    private Vector3 posBeforeChange;

    private int flash_time;

    // Start is called before the first frame update
    void Start()
    {
        flash_time = 0;

        toggled = false;
        isReset = false;

        origin = transform.position;

        secondaryGlow.SetActive(false);
        flare.SetActive(false);
        saveGlow.SetActive(false);

        pos = new List<Vector3>();
        posIndex = -1;

        timerStarted = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("s"))
        {
            pos.Add(transform.position);
            posIndex++;
            saveGlow.SetActive(true);

            flash_time = 1;
        }

        if(flash_time != 0)
        {
            flash_time++;

            if(flash_time == 20)
            {
                saveGlow.SetActive(false);
                flash_time = 0;
            }
        }

        if(toggled)
        {
            particleSystem.Play();

            timerStarted = true;
            posBeforeChange = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            GetComponent<Draggable>().isDragged = false;

            transform.parent = null;

            secondaryGlow.SetActive(true);
            flare.SetActive(true);

            posIndex++;

            int count = pos.Count;

            if (posIndex >= count)
            {
                posIndex -= count;
            }

            camera.GetComponent<bobbingCamera>().timeScale = 3;

            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<wave>().timeScale = 10;
                lights[i].GetComponent<wave>().waveScale = 20;
            }

            toggled = false;
        }

        if(Input.GetKeyDown("l"))
        {
            toggled = true;
        }

        if(Input.GetKeyDown("r"))
        {
            transform.position = origin;

            posBeforeChange = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            timerStarted = true;
            isReset = true;

            particleSystem.Play();

            timerStarted = true;
            posBeforeChange = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            GetComponent<Draggable>().isDragged = false;

            transform.parent = null;

            secondaryGlow.SetActive(true);
            flare.SetActive(true);

            camera.GetComponent<bobbingCamera>().timeScale = 3;

            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<wave>().timeScale = 10;
                lights[i].GetComponent<wave>().waveScale = 20;
            }
        }

        if(timerStarted)
        {
            GetComponent<BoxCollider2D>().enabled = false;

            time++;

            Vector3 deltaVector;

            if (!isReset && posIndex >= 0 && posIndex < pos.Count)
            {
                deltaVector = (pos[posIndex] - posBeforeChange) / 20f;
            }
            else
            {
                deltaVector = (origin - posBeforeChange) / 20f;
            }

            transform.position = posBeforeChange + time * deltaVector;

            if (time == 20)
            {
                isReset = false;

                secondaryGlow.SetActive(false);
                flare.SetActive(false);

                timerStarted = false;
                time = 0;
                GetComponent<BoxCollider2D>().enabled = true;

                camera.GetComponent<bobbingCamera>().timeScale = 300;

                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].GetComponent<wave>().timeScale = 60;
                    lights[i].GetComponent<wave>().waveScale = 5;
                }
            }
        }
    }
}
