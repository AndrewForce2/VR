using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maximumSpeed = 5.5f;
    public float acceleration = 1f;
    public float gravity = 10f;
    public bool canJump;
    public float jumpingCooldown = 0.6f;
    public bool reachedFinishLine = false;

    private float speed = 0f;
    private float jumpingTimer = 0f;
    private CharacterController controller;
    public GameObject feet;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        if (speed > maximumSpeed)
        {
            speed = maximumSpeed;
        }
        //Move the player forward
        //transform.position += speed * Vector3.forward * Time.deltaTime;
        PlayerMovement();
        jumpingTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (jumpingTimer <= 0f)
            {
                StartCoroutine(EnableJump());
                jumpingTimer = jumpingCooldown;
            }
            Debug.Log("Mouse0!!!");
        }
    }

    IEnumerator EnableJump()
    {
        gravity = -gravity;
        yield return new WaitForSeconds(0.3f);
        gravity = -gravity;
    }

    void PlayerMovement()
    {
        Vector3 velocity = speed * Vector3.forward;
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Obstacle")
        {
            speed *= 0.3f;
        }

        if (collider.tag == "FinishLine")
        {
            reachedFinishLine = true;
        }
    }
}
