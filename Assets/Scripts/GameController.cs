using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMesh infoText;
    public Player player;

    private float gameTimer = 0f;
    private float restartTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.reachedFinishLine == false)
        {
            gameTimer += Time.deltaTime;
            infoText.text = "Avoid the obstacles! \n Press the button to jump! \n Time: " + Mathf.Floor(gameTimer);
        }
        else
        {
            infoText.text = "You win! \n Your Time: " + Mathf.Floor(gameTimer);

            restartTimer -= Time.deltaTime;
            if(restartTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
