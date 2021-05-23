using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 3.5f;
    public float jumpForce = 10f;
    public int score;

    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }

        //move forward
        GetComponent<Rigidbody>().velocity = new Vector3(
                0,
                GetComponent<Rigidbody>().velocity.y,
                speed
            ) ;

        //Make bird jump
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(
                0,
                jumpForce,
                GetComponent<Rigidbody>().velocity.z
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            dead = true;
        }
        if(other.tag == "Point")
        {
            score++;
        }
    }
}
