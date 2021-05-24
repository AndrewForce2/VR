using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject motorcycle;
    public float acceleration = 0.5f;
    public float maximumSpeed = 10f;
    public float obstacleSlowdown = 0.25f;
    public bool hasReachedFinishLine;

    public float speed = 2f;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Acceleration logic

        speed += acceleration * Time.deltaTime;
        if(speed > maximumSpeed)
        {
            speed = maximumSpeed;
        }

        Vector3 direction = new Vector3(
                Camera.main.transform.forward.x,
                0,
                Camera.main.transform.forward.z
            );

        if (Camera.main.transform.forward.z < 0)
        {
            direction = Vector3.zero;
        }
        transform.position += direction.normalized * speed * Time.deltaTime;

        if(transform.position.x < -5f)
        {
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 5f)
        {
            transform.position = new Vector3(5f, transform.position.y, transform.position.z);
        }

        motorcycle.transform.eulerAngles = new Vector3(
                motorcycle.transform.eulerAngles.x,
                Camera.main.transform.eulerAngles.y + 90f,
                motorcycle.transform.eulerAngles.z
            );
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            speed -= 2.4f;
        }
        else if(other.tag == "FinishLine")
        {
            hasReachedFinishLine = true;
        }
    }
}
