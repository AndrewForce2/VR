using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float verticalForce = 400.0f;
    public float horizontalForce = 150f;
    public float lifetime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3 (
                Random.Range(-horizontalForce, horizontalForce),
                verticalForce,
                0
            ));
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
