using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bowlingBall;
    public float ballDistance = 2.25f;
    public float ballThrowingForce = 200f;

    public bool holding = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(holding)
        {
            bowlingBall.transform.position = Camera.main.transform.position + Camera.main.transform.forward * ballDistance;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                holding = false;
            }
        }
        else
        {
            bowlingBall.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * ballThrowingForce);
            
        }
       
    }
}
