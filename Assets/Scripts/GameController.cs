using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMesh infoText;
    public Basketball basketball;
    public Player player;
    public GameObject shootingTarget;

    private float basketballTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "Press once to calculate force, \n press another time to throw \n \n";
        infoText.text += "Score: " + basketball.score;
        
        if(basketball.hitSomething && basketballTimer <= 0f)
        {
            basketballTimer = 3f;
        }
        if(basketballTimer > 0f)
        {
            basketballTimer -= Time.deltaTime;
            if(basketballTimer <= 0f)
            {
                if(basketball.gotRightTarget == true)
                {
                    player.PickBasketball();
                    shootingTarget.transform.position = new Vector3(
                            Random.Range(-7, -1),
                            shootingTarget.transform.position.y,
                            shootingTarget.transform.position.z
                        ) ;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
