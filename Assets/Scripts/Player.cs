using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canPick = false;

    public bool picked = false;
    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {   
        transform.position = new Vector3(
                0,
                0,
                2.476f
            );
    }

    // Update is called once per frame
    void Update()
    {

        if (canPick)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(hit.transform.name);
                Cup cup = hit.transform.GetComponent<Cup>();
                if (cup != null)
                {
                    canPick = false;

                    picked = true;
                    won = (cup.ball != null);
                    cup.MoveUp();
                }
            }
        }
    }
}
