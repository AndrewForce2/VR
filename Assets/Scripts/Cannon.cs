using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float shootingForce = 5.2f;
    public GameObject cannonballPrefab;
    public int shotsFired = 0;

    public bool hasShots = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && hasShots == true)
        {
            GameObject cannonballObject = Instantiate(cannonballPrefab);
            cannonballObject.transform.position = transform.position;
            cannonballObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootingForce) ;

            shotsFired++;
        }
    }
}
