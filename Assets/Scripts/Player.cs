using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject sword;
    public float speed = 4.5f;
    public float walkingAmplitude = 0.25f;
    public float walkingFrequency = 2.0f;
    public float swordRange = 1.75f;
    public float swordCooldown = 0.25f;
    public bool isDead = false;
    public bool hasCrossedFinishLine = false;

    private Vector3 lastLocation;
    private float coolDownTimer;
    public CharacterController controller;
    private Vector3 swordTargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        swordTargetPosition = sword.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead) { return; }
        //transform.position += Vector3.forward * speed * Time.deltaTime;
        PlayerMovement();
        transform.position = new Vector3(
                transform.position.x,
                1.7f + Mathf.Cos(transform.position.z * walkingFrequency) * walkingAmplitude,
                transform.position.z
            );

        coolDownTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            if (coolDownTimer <= 0f && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                coolDownTimer = swordCooldown;
                if (hit.transform.GetComponent<Enemy>() != null && hit.transform.position.z - this.transform.position.z <= swordRange)
                {
                    Destroy(hit.transform.gameObject);
                    swordTargetPosition = new Vector3(
                            -swordTargetPosition.x,
                            swordTargetPosition.y,
                            swordTargetPosition.z
                    );
                }
            }
        }
        sword.transform.localPosition = Vector3.Lerp(sword.transform.localPosition, swordTargetPosition, Time.deltaTime * 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>() != null)
        {
            isDead = true;
        }
        else if(other.tag == "FinishLine")
        {
            hasCrossedFinishLine = true;
        }
    }

    void PlayerMovement()
    {
        Vector3 velocity = speed * Vector3.forward;
        controller.Move(velocity * Time.deltaTime);
    }
}
