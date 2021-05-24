using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    public TextMesh infoText;
    public Ghost ghost;

    private float restartTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Reach the treasure!\nLook away to stop moving!";

        if(ghost.centeredLook && player.moving)
        {
            player.spotted = true;
        }

        if(player.reachedTreasure)
        {
            infoText.text = "You won!";

            restartTimer -= Time.deltaTime;
            if(restartTimer <= 0f )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if (player.spotted)
        {
            infoText.text = "You have been spotted :(";

            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
