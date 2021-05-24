using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Kart kart;
    public TextMesh infoText;

    private float timer;
    private float recordTime = 999;
    private int kartLap = 0;
    // Start is called before the first frame update
    void Start()
    {
        kart.infoText = infoText;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(kart.CurrentLap > kartLap)
        {
            kartLap = kart.CurrentLap;

            if(timer < recordTime)
            {
                recordTime = timer;
            }

            timer = 0;
        }

        if(!kart.checkpoint)
        {
            infoText.text = "Time: " + Mathf.Floor(timer);
            if (recordTime < 999)
            {
                infoText.text += "\nRecord: " + Mathf.FloorToInt(recordTime);
            }
        }
    }
}
