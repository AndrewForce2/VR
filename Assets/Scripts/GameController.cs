using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    public Mission[] missionsCompleted;
    public TextMesh infoText;
    public int house;

    private float santaTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < missionsCompleted.Length; i++)
        {
            if (missionsCompleted[i].hasMissions == false && missionsCompleted[i].houseDone == false)
            {
                house++;
                missionsCompleted[i].houseDone = true;
            }
        }

        if (player.hasFinished)
        {
            santaTimer -= Time.deltaTime;
            infoText.text = "Merry Christmas! \n Gifted Houses: " + house;
            if(house < missionsCompleted.Length)
            {
                infoText.text += "\n Maybe next year :(";
            }
            else infoText.text += "\n You are the best, Santa! :D";
            if(santaTimer < 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else infoText.text = "Throw gifts in the stove pipes!";
    }
}
