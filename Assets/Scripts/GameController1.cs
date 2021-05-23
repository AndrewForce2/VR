using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    public Player player;
    public TextMesh infoText;
    public Pin[] pins;

    public float evaluationTime = 10f;

    private float gameTimer = 0f;
    private bool evaluating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Throw the bowling ball!" + '\n' + "Timer: " + Mathf.Floor(gameTimer);

        if(evaluating == false)
        {
            if(player.holding == false)
            {
                evaluating = true;
                gameTimer = evaluationTime;
            }
        }
        else
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0f)
            {
                int score = 0;
                for (int i = 0; i < pins.Length; i++)
                {
                    if (pins[i] == null)
                    {
                        score++;
                    }
                }
                if(score == 10)
                {
                    infoText.text = "STRIKE";
                }
                else infoText.text = "Your score: " + score;
            }

            if (gameTimer <= -3f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
