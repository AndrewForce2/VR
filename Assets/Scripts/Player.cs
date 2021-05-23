using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int deflectedBaseballs;
    public Camera camera;
    public float hitDistance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            if(Physics.Raycast(camera.transform.position, camera.transform.forward,out hit))
            {
                if(hit.transform.tag == "Baseball")
                {
                    Baseball baseball = hit.transform.GetComponent<Baseball>();
                    if (baseball.transform.position.z - transform.position.z < hitDistance)
                    {
                        bool deflected = baseball.Deflect();

                        if(deflected)
                        {
                            deflectedBaseballs++;
                        }
                    }
                }
            }
        }
    }
}
