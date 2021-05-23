using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 direction;
    public Nexus nexus;

    public int damage = 3;
    public float speed = 3.5f;
    public float distanceToStop = 1f;
    public bool chasingPlayer = true;

    public float eatingInterval = 0.5f;


    private float eatingTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, nexus.transform.position) < distanceToStop)
        {
            chasingPlayer = false;
        }

        if (chasingPlayer)
        {
            direction = (nexus.transform.position - transform.position).normalized;
            transform.LookAt(nexus.transform);
            transform.position += direction * speed * Time.deltaTime;
        } 
        else
        {
            eatingTimer -= Time.deltaTime;
            if(eatingTimer <= 0f)
            {
                eatingTimer = eatingInterval;

                nexus.health -= damage;
            }
        }
    }
}
