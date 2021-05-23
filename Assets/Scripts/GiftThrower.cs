using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GiftThrower : MonoBehaviour
{
    public float giftDistance = 10f;
    public float giftAltitude = 2f;
    public GameObject gift;
    public GameObject sled;

    private float throwingTimer;

    Vector3 startPosition;
    Vector3 Altitude0, Altitude1, Altitude2; 
    Vector3 Distance0, Distance1, Distance2;
    
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        throwingTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(throwingTimer < 0f)
            {

            int i = Random.Range(0, 3);
            gift = Instantiate(Resources.Load("Gift" + i)) as GameObject;

            gift.transform.position = transform.position;

            startPosition = transform.position;
            Altitude0 = transform.up * giftAltitude;
            Altitude1 = transform.up * (giftAltitude + 0.1f);
            Altitude2 = transform.forward;

            Distance0 = transform.forward * giftDistance;
            Distance1 = transform.forward * (giftDistance + 0.4f);
            Distance2 = transform.forward * (giftDistance + 0.6f);

            StartCoroutine(Throw());
            throwingTimer = 2f;
            }
        }

    }

    IEnumerator Throw()
    {
        for(float t= 0f; t <= 1f; t+=0.01f)
        {
            gift.transform.position = Calculate(t);
            yield return new WaitForSeconds(0.001f);
        }
        gift.GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
        gift.GetComponent<Rigidbody>().useGravity = true ;
    }
    Vector3 Calculate(float t)
    {
        return CalculateCubicBezierPoint(
            t,
            startPosition , // P0
            startPosition + Altitude0 + Distance0, //P1
            startPosition + Altitude1 + Distance1, //P2
            startPosition + Altitude2 + Distance2 //P3
            );
    }
    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

}
