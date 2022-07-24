using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public float movementSpeed;

    public float acceleration;
    public float velocity;
    public float maxVelocity;

    public int facing = 0;

    private string lastCollisionName;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 0f;
        lastCollisionName = "Ground";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += acceleration;

            if(velocity > maxVelocity)
            {
                velocity = maxVelocity;
            }

            player.GetComponent<Animator>().SetBool("running", true);

            transform.position += new Vector3(-1f * movementSpeed * velocity, 0f, 0f) * Time.deltaTime;

            if (facing == 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);

                facing = 1;
            }
        }else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            velocity += acceleration;

            if (velocity > maxVelocity)
            {
                velocity = maxVelocity;
            }

            player.GetComponent<Animator>().SetBool("running", true);

            transform.position += new Vector3(1f * movementSpeed * velocity, 0f, 0f) * Time.deltaTime;

            if (facing == 1)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);

                facing = 0;
            }
        }
        else
        {
            velocity -= acceleration;

            if (velocity < 0)
            {
                velocity = 0;
            }

            if (facing == 0)
            {
                transform.position += new Vector3(1f * movementSpeed * velocity, 0f, 0f) * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(-1f * movementSpeed * velocity, 0f, 0f) * Time.deltaTime;
            }

            player.GetComponent<Animator>().SetBool("running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (lastCollisionName == "Ground" || lastCollisionName == "Door" || lastCollisionName == "Cube" || lastCollisionName == "Cube (1)" || lastCollisionName == "Cube (2)")
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * 300);

                lastCollisionName = "ur mom";
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        lastCollisionName = collision2D.collider.name;
    }
}
