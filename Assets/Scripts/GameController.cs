using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public Player player;
    public float horizontalArea = 3f;
    public float spawnDuration = 3f;
    public TextMesh infoText;

    public float spawnHeight;
    public float spawnWidth;

    public float gameTimer = 15f;

    private float spawnTimer;
    private float resetTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                spawnTimer = spawnDuration;

                for (int i = 0; i < 3; i++)
                {
                    GameObject fruit = Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]);
                    fruit.transform.position = new Vector3(
                            Random.Range(-horizontalArea, horizontalArea),
                            spawnHeight,
                            spawnWidth
                        );
                }
            }
            infoText.text = "Slash the fruits!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score;
        } 
        else
        {
            infoText.text = "Game over! Score: " + player.score;

            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
