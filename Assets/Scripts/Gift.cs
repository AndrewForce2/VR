using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public Mission mission;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Stove Pipe")
        {
            Debug.Log("GIFTED!");
            other.GetComponent<Mission>().missions -= 1;
             Destroy(gameObject);
        }
        if (other.tag == "WrongTarget") Destroy(gameObject);
    }
}
