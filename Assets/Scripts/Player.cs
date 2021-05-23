using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Basketball basketball;
    public Vector3 basketballOffset;
    public float basketballDistance = 1f;
    public float shootingForce = 500f;
    public float minimumShootingForce = 400f;
    public float maximumShootingForce = 1000f;
    public GameObject[] levels;
    public Material[] levelMaterials;
    public Material basic;

    private float shootingTimer = 0f;
    private bool calculatingShot = false;
    private bool holdingBasketball;
    // Start is called before the first frame update
    void Start()
    {
        holdingBasketball = true;
    }

    public void PickBasketball()
    {
        shootingTimer = 0f;
        holdingBasketball = true;
        calculatingShot = false;

        basketball.hitSomething = false;
        Debug.Log(basketball.hitSomething);
        for(int i = 0; i < levels.Length; i++)
        {
            levels[i].GetComponent<Renderer>().material = basic;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBasketball)
        {
            basketball.transform.position = transform.position + transform.forward * basketballDistance + basketballOffset;
            basketball.GetComponent<Rigidbody>().useGravity = false;
            if(calculatingShot)
            {
                shootingTimer += Time.deltaTime * 0.25f;
                Meter(shootingTimer);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (calculatingShot == false) { calculatingShot = true; }
                else if (holdingBasketball)
                {
                    holdingBasketball = false;
                    basketball.GetComponent<Rigidbody>().useGravity = true;

                    float calculatedScale = Mathf.Min(shootingTimer, 1f);
                    float calculatedForce = minimumShootingForce + (maximumShootingForce - minimumShootingForce) * calculatedScale;

                    basketball.GetComponent<Rigidbody>().AddForce(this.transform.forward * calculatedForce);

                }
            }
        }

        void Meter(float shootingTimer)
        {
            if (shootingTimer <= 0.25f)
            {
                levels[0].GetComponent<Renderer>().material = levelMaterials[0];
            }
            if (shootingTimer > 0.25f && shootingTimer <= 0.5f)
            {
                levels[1].GetComponent<Renderer>().material = levelMaterials[1];
            }
            if (shootingTimer > 0.5f && shootingTimer <= 0.75f)
            {
                levels[2].GetComponent<Renderer>().material = levelMaterials[2];
            }
            if (shootingTimer > 0.75f)
            {
                levels[3].GetComponent<Renderer>().material = levelMaterials[3];
            }
        }
            
    }
}
