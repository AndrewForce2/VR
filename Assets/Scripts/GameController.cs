using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Nexus nexus;
    public GameObject enemyPrefab;
    public TextMesh infoText;

    public float enemySpawnDistance = 20f;

    public float enemyInterval = 2.0f;
    public float minimumEnemyInterval = 0.5f;
    public float enemyIntervalDecrement = 0.1f;

    private float gameTimer = 0f;
    private float enemyTimer = 0f;
    private float resetTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nexus.health > 0)
        {
            gameTimer += Time.deltaTime;
            infoText.text = "Nexus HP: " + nexus.health;
            infoText.text += "\nTime: " + Mathf.Floor(gameTimer);
        } else
        {
            infoText.text = "Nexus destroyed :(";
            infoText.text += "\nYou survived for " + Mathf.Floor(gameTimer) + " seconds!";

            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        enemyTimer -= Time.deltaTime;
        if(enemyTimer <= 0f)
        {
            enemyTimer = enemyInterval;
            enemyInterval -= enemyIntervalDecrement;

            if(enemyInterval < minimumEnemyInterval)
            {
                enemyInterval = minimumEnemyInterval;
            }

            GameObject enemyObject = Instantiate(enemyPrefab);
            Enemy enemy = enemyObject.GetComponent<Enemy>();

            float randomAngle = Random.Range(0f, Mathf.PI * 2f);
            enemy.transform.position = new Vector3(
                nexus.transform.position.x + Mathf.Cos(randomAngle) * enemySpawnDistance,
                nexus.transform.position.y,
                nexus.transform.position.z + Mathf.Sin(randomAngle) * enemySpawnDistance
                );

            enemy.nexus = nexus;
        }
    }
}
