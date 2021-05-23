using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public float downHeight = 0.75f;
    public float upHeight = 1f;
    public float movingSpeed = 0.3f;

    public GameObject ball;
    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        downHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if (started_option == true)
        //{
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movingSpeed);
            
            if (ball != null)
            {
            ball.transform.position = new Vector3(
                    transform.position.x,
                    ball.transform.position.y,
                    transform.position.z
                );
            }
        //    if (Vector3.Distance(transform.position, targetPosition) < 1)
        //        started_option = false;
        //}
        //Debug.Log(targetPosition.y);
    }

    public void MoveUp ()
    {
        targetPosition = new Vector3(
                transform.position.x,
                upHeight,
                transform.position.z
            );
    }

    public void MoveDown()
    {
        targetPosition = new Vector3(
                transform.position.x,
                downHeight,
                transform.position.z
            );
    }
}
