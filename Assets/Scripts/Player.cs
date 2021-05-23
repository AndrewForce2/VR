using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    public float gravity = -9.81f;
    public float MovementSpeed = 4f;
    public bool hasKey = false;

    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((Camera.main.transform.right * horizontal + Camera.main.transform.forward * vertical) * Time.deltaTime);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(hit.transform.tag == "CorrectItem")
                {
                    hasKey = true;

                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
