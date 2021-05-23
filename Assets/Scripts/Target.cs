using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public float minimumHorizontalForce;
    public float minimumVerticalForce;
    public float maximumHorizontalForce;
    public float maximumVerticalForce;

    public Action onHitFloor;

    // Start is called before the first frame update
    void Start()
    {
        int ThrowDirection = 1;

        if(transform.position.z > 0)
        {
            ThrowDirection = -1;
        }
        GetComponent<Rigidbody>().AddForce(new Vector3 (
                0,
                Random.Range(minimumVerticalForce, maximumVerticalForce) ,
                Random.Range(minimumHorizontalForce, maximumHorizontalForce) * ThrowDirection
            ));
    }

    // Update is called once per frame
    void Update()
    {
        //Clay Curve
        transform.LookAt(transform.position + GetComponent<Rigidbody>().velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Bullet>() != null)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if(other.transform.name == "Floor")
        {
            if(onHitFloor != null)
            {
                onHitFloor ();
            }
        }
    }
}
