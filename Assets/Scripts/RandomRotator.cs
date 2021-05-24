using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float speed = 200f;
    private bool positiveX;
    private bool positiveY;
    private bool positiveZ;

    // Start is called before the first frame update
    void Start()
    {
        positiveX = Random.Range(0f, 1f) > 0.5f;
        positiveY = Random.Range(0f, 1f) > 0.5f;
        positiveZ = Random.Range(0f, 1f) > 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, speed * (positiveY ? 1 : -1) * Time.deltaTime);
        transform.RotateAround(transform.position, Vector3.right, speed * (positiveX ? 1 : -1) * Time.deltaTime);
        transform.RotateAround(transform.position, Vector3.forward, speed * (positiveZ ? 1 : -1) * Time.deltaTime);
    }
}
