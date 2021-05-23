using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    public float lifetime = 5f;
    public float speed = 4.5f;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public bool Deflect()
    {
        if(direction.z < 0)
        {
            direction = new Vector3(direction.x, direction.y, -direction.z);
            return true;
        }
        else
        {
            return false;
        }
    }
}
