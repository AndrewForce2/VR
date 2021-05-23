using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public bool hasFinished = false;
    CharacterController controller;
    float keepHeight;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        keepHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(transform.forward * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, keepHeight, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FinishLine")
        {
            hasFinished = true;
            speed = 0;
        }
    }
}
