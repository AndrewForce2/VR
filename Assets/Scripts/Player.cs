using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public GameObject bulletPrefab;
    public Weapon weapon;
    
    public float gravity = -9.81f;
    public float MovementSpeed = 4f;
    public float shootingCooldown = 0.1f;
    public float bulletHeight = 0.5f;


    private CharacterController characterController;
    private float shootingTimer;
    private Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer -= Time.deltaTime;
        velocity.y += gravity * Time.deltaTime;

        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((Camera.main.transform.right * horizontal + Camera.main.transform.forward * vertical) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootingTimer = shootingCooldown;

            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = weapon.transform.position + new Vector3(0, bulletHeight, 0);

            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.direction = Camera.main.transform.forward;
        }
    }
}
