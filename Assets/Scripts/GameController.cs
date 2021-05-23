using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    public GameObject door;
    public TextMesh gameText;
    public GameObject itemContainer;
    public float itemSize = 0.45f;

    private Vector3 originalDoorPosition;
    private float gameTimer;
    private float gameOverTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        originalDoorPosition = door.transform.position;

        GameObject randomItem = itemContainer.transform.GetChild(Random.Range(0, itemContainer.transform.childCount)).gameObject;
        randomItem.transform.localScale += Vector3.one * itemSize;
        randomItem.tag = "CorrectItem";
        Debug.Log(randomItem.transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.hasKey)
        {
            door.transform.position = Vector3.Lerp(
                    door.transform.position,
                    originalDoorPosition + new Vector3(0, 10f, 0),
                    Time.deltaTime
                ); ;

            gameText.text = "You escaped :D\nTime: " + Mathf.FloorToInt(gameTimer);

            gameOverTimer -= Time.deltaTime;
            if(gameOverTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            gameTimer += Time.deltaTime;

            gameText.text = "Find the key!\nTime: " + Mathf.FloorToInt(gameTimer);
        }
    }
}
