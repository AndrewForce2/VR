using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject target;
    public TextMesh infoText;
    public float stareDuration = 1f;
    public float targetDistance = 5f;
    public float gameDuration = 16f;

    private float stareTimer;
    private int hits;
    private float gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        stareTimer = 0f;
        gameTimer = gameDuration;
    }

    // Update is called once per frame
    void Update()
    {

        gameTimer -= Time.deltaTime;
        if(gameTimer >= 0f)
        {
            infoText.text = "Hits: " + hits;
            infoText.text += "\nTimer: " + Mathf.Floor(gameTimer);

            RaycastHit hit;

            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit))
            {
                if (hit.transform.name == "Target")
                {
                    stareTimer += Time.deltaTime;
                }
                else
                {
                    stareTimer = 0f;
                }
            }

            // Check if it's time to teleport the target

            if (stareTimer >= stareDuration)
            {
                stareTimer = 0f;

                hits++;

                MoveCube();
            }
        }
        else
        {
            infoText.text = "Game over! Your score: " + hits;
            if(gameTimer < -4f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    void MoveCube()
    {
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        target.transform.position = new Vector3(
                Mathf.Cos(randomAngle) * targetDistance,
                Random.Range(0, targetDistance),
                Mathf.Sin(randomAngle) * targetDistance
            );
    }
}
