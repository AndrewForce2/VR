using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public float shootingCooldown = 0.5f;
    private float shootingTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer -= Time.deltaTime;

        RaycastHit hit;

        if(Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit))
        {
            if(hit.transform.GetComponent<Target>() != null && shootingTimer <= 0f)
            {
                shootingTimer = shootingCooldown;

                GameObject bulletObject = Instantiate(bulletPrefab);
                bulletObject.transform.position = gameCamera.transform.position;

                Bullet bullet = bulletObject.GetComponent<Bullet>();
                bullet.direction = gameCamera.transform.forward;
                bullet.speed = bulletSpeed;
            }
        }
    }
}
