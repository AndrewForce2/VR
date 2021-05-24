using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;
    public GameObject asteroidPrefab;
    public TextMesh scoreText;

    public float spawnDistance = 5f;
    public float spawnIncrement = 1f;

    public float spawnPointer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z > spawnPointer)
        {
            
            int satId = Random.Range(1, 4);
            
            GameObject asteroidObject = Instantiate(Resources.Load("Sat"+satId)) as GameObject;
            Debug.Log(asteroidObject.transform.name);
            asteroidObject.transform.position = new Vector3(
                    Random.Range(-1.5f, 1.5f),
                    Random.Range(-1.5f, 1.5f),
                    player.transform.position.z + spawnDistance
                );
            asteroidObject.transform.Rotate(
                    Random.Range(0f, 359f),
                    Random.Range(0f, 359f),
                    Random.Range(0f, 359f), 
                    Space.Self
                );

            spawnPointer = player.transform.position.z + spawnIncrement;
        }

        int playerScore = Mathf.RoundToInt(player.transform.position.z);
        if(playerScore < 0)
        {
            playerScore = 0;
        }
        scoreText.text = "Score: " + playerScore;
    }
}
