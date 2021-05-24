using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMesh infoText;
    public Player player;

    private float restartTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "Race to the finish!";
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isDead)
        {
            infoText.text = "You lost :(";

            restartTimer -= Time.deltaTime;
            if(restartTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if(player.hasCrossedFinishLine)
        {
            infoText.text = "You won! \n Congratulations! :D";

            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
