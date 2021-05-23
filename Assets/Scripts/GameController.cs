using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public TextMesh infoText;
    public Player player;
    public GameObject ball;
    public Cup[] cups;

    private float resetTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "Pick the correct cup!";
        player.GetComponent<Player>();
        Debug.Log("GameController!");
        StartCoroutine(ShuffleRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (player.picked)
        {
            if (player.won)
            {
                infoText.text = "You win!";
            }
            else
            {
                infoText.text = "You lose :( try again!";
            }

            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0f)
            {
                SceneManager.LoadScene("Cups_Balls");
            }
        }
    }

    IEnumerator ShuffleRoutine ()
    {
        yield return new WaitForSeconds(1f);
        foreach (Cup cup in cups)
        {
            cup.MoveUp();
        }

        yield return new WaitForSeconds(0.5f);

        Cup targetCup = cups[Random.Range(0, cups.Length)];
        
        targetCup.ball = GameObject.Find("Ball");
        ball.transform.position = new Vector3 (
                targetCup.transform.position.x,
                ball.transform.position.y,
                targetCup.transform.position.z
            );

        yield return new WaitForSeconds(1.0f);
        foreach(Cup cup in cups)
        {
            cup.MoveDown();
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < 5; i++)
        {
            Cup cup1 = cups[Random.Range(0, cups.Length)];
            Cup cup2 = cup1;

            while (cup2 == cup1)
            {
                cup2 = cups[Random.Range(0, cups.Length)];
            }

            Vector3 cup1Position = cup1.targetPosition;
            cup1.targetPosition = cup2.targetPosition;
            cup2.targetPosition = cup1Position;

            yield return new WaitForSeconds(0.75f);
        }
        player.canPick = true;
    }
}