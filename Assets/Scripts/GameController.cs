using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMesh infoText;
    public Player player;
    public PropContainer propContainer;

    private float gameTimer;
    private float restartTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        int propsRemaining = propContainer.amountOfProps - player.propsCollected;
        if(!player.Found) 
        {
            infoText.transform.LookAt(player.transform.position);
            infoText.transform.eulerAngles -= new Vector3(0, 180, 0);
            if (propsRemaining > 0)
            {
                gameTimer += Time.deltaTime;
                infoText.text = "Collect all these evidences!\nRemaining: " + propsRemaining;
                infoText.text += "\nTime: " + Mathf.FloorToInt(gameTimer);
            }
            else
            {
                player.infoText.text = "You got all the props!\nYour time: " + Mathf.FloorToInt(gameTimer);

                restartTimer -= Time.deltaTime;
                if (restartTimer < 0f)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
