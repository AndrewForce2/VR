using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public TextMesh missionsText;
    public int missions;
    public bool hasMissions = true;
    public bool houseDone = false;
    // Start is called before the first frame update
    void Start()
    {
        missions = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
            if(missions <= 0)
            {
                missionsText.text = "0";
                hasMissions = false;
            }
            else missionsText.text = Mathf.Floor(missions).ToString();
    }
}
