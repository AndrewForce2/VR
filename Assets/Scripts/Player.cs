using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject treasure;
    public float speed = 4.5f;
    public bool moving = false;

    public bool spotted = false;
    public bool reachedTreasure = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Camera.main.transform.forward, out hit))
        {
            if(hit.transform.tag == "LookingArea")
            {
                moving = true;
            }
            else
            {
                moving = false;
            }
        }
        else
        {
            moving = false;
        }

        if (moving && !reachedTreasure && !spotted)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if(transform.position.z >= treasure.transform.position.z - 1f)
        {
            reachedTreasure = true;
        }
    }
}
