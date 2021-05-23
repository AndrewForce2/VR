using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMesh infoText;
    public int propsCollected = 0;
    public float gravity = -9.81f;
    public float MovementSpeed = 4f;
    public float walkingAmplitude = 0.25f;
    public float walkingFrequency = 2.0f;
    public bool Found;

    private CharacterController characterController;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if(hit.transform.tag == "TargetProp")
                {
                    Destroy(hit.transform.gameObject);
                    StartCoroutine(GotProp(hit));
                    propsCollected++;
                }
            }
        } 
    }

    IEnumerator GotProp(RaycastHit hit)
    {
        Found = true;
        string backup = infoText.text;
        infoText.text = "You found a " + hit.transform.name;
        yield return new WaitForSeconds(2f);
        infoText.text = "";
        Found = false;
    }
    void Movement()
    {
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((Camera.main.transform.right * horizontal + Camera.main.transform.forward * vertical) * Time.deltaTime);

        transform.position = new Vector3(
                transform.position.x,
                0.5f + Mathf.Cos(transform.position.z * walkingFrequency) * walkingAmplitude,
                transform.position.z
            );
    }
}
