using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float movementAmplitude = 0.1f;
    public float movementFrequency = 1f;

    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Vector3.forward * Time.deltaTime;
        transform.localPosition = new Vector3(
                transform.localPosition.x,
                Mathf.Cos(transform.position.z * movementFrequency) * movementAmplitude,
                transform.localPosition.z
            ) ;
    }
}
