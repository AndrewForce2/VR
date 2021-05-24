using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMesh infoText;
    public GameObject[] obstaclePrefabs;
    public Player player;
    public GameObject finishLine;

    public float spawnDistanceFromPlayer = 20f;
    public float spawnDistanceFromObstacles = 5f;
    public float finishLinePosition = 200f;

    private AudioSource audio;
    private float obstaclePointer;
    private float gameTimer;
    private float gameOverTimer = 3f;
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
        finishLine.transform.position = new Vector3(
                finishLine.transform.position.x,
                finishLine.transform.position.y,
                finishLinePosition
            ) ;
    }

    // Update is called once per frame
    void Update()
    {
        if(obstaclePointer < player.transform.position.z)
        {
            obstaclePointer += spawnDistanceFromObstacles;

            GameObject obstacleObject = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
            obstacleObject.transform.position = new Vector3(
                    Random.Range(-4f, 4f),
                    obstacleObject.transform.position.y,
                    player.transform.position.z + spawnDistanceFromPlayer
                ) ;
            obstacleObject.transform.eulerAngles = new Vector3(
                    0,
                    Random.Range(-30f, 30f),
                    0
                );
        }

        

        if(!isGameOver) 
        {
            if (player.hasReachedFinishLine)
            {
                isGameOver = true;
            }
            gameTimer += Time.deltaTime;
            infoText.text = "Time: " + Mathf.FloorToInt(gameTimer);

        } else
        {
            infoText.text = "Game over!\nYour time: " + Mathf.FloorToInt(gameTimer) ;

            gameOverTimer -= Time.deltaTime;
            if(gameOverTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
