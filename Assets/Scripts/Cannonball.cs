using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float lifetime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterSeconds();
    }

    void DestroyAfterSeconds()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
        }
    }
}
