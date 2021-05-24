using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Player player;
    public float turningDuration = 3f;
    public float turningSpeed = 3f;
    public bool centeredLook = false;

    private float turningTimer = 2f;
    private Quaternion targetRotation;
    private Quaternion lookingToPlayerRotation;
    private Quaternion lookingAwayFromPlayerRotation;
    // Start is called before the first frame update
    void Start()
    {
        lookingAwayFromPlayerRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        lookingToPlayerRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        transform.rotation = lookingAwayFromPlayerRotation;
        targetRotation = lookingAwayFromPlayerRotation;
    }

    // Update is called once per frame
    void Update()
    {
        turningTimer -= Time.deltaTime;
        if(turningTimer <= 0f && !player.reachedTreasure)
        {
            turningTimer = turningDuration;

            if (targetRotation == lookingAwayFromPlayerRotation)
            {
                targetRotation = lookingToPlayerRotation;
            }
            else
            {
                targetRotation = lookingAwayFromPlayerRotation;
            }
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turningSpeed);
    
        if(Mathf.Abs(transform.localEulerAngles.y) < 1 || Mathf.Abs(transform.localEulerAngles.y) > 359)
        {
            centeredLook = true;
        }
        else
        {
            centeredLook = false;
        }
    }
}
