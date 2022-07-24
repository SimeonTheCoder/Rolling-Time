using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public GameObject player;
    public float treshold;

    public GameObject endScreen;

    private bool timerStarted;
    private bool restart;
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);

        time = 0;
        timerStarted = false;
        restart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerStarted)
        {
            time++;

            if(time == 200)
            {
                if (!restart)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        Vector3 difference = player.transform.position - transform.position;

        float distance = Mathf.Sqrt(difference.x * difference.x + difference.y * difference.y + difference.z * difference.z);

        if(distance < treshold && transform.localScale.x <= 1)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.03f, transform.localScale.y, transform.localScale.z);
        }

        if(Input.GetKey("t"))
        {
            timerStarted = true;
            restart = true;
            endScreen.GetComponent<Animator>().SetBool("exit", true);
        }
    }

    public void call()
    {
        timerStarted = true;
        endScreen.GetComponent<Animator>().SetBool("exit", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            call();
        }
    }
}
