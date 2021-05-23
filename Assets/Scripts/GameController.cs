using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public GameObject targetPrefab;
    public TextMesh scoreText;

    private float targetInterval = 1f;
    private int targetToShoot = 1;
    private bool isGameOver = false;

    private float restartTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            scoreText.text = "Level: " + targetToShoot;
        }
        else
        {
            scoreText.text = "Game over!\nYour score: " + targetToShoot;

            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    private IEnumerator ShootingRoutine()
    {
        for (int i = 0; i < targetToShoot; i++)
        {
            SpawnTarget();

            yield return new WaitForSeconds(targetInterval);
        }

        yield return new WaitForSeconds(3f);

        if(isGameOver == false)
        {
            targetToShoot++;
            StartCoroutine(ShootingRoutine());
        }
    }

    void SpawnTarget()
    {
        GameObject targetObject = Instantiate(targetPrefab);
        targetObject.transform.position = new Vector3(
                16,
                2,
                Random.Range(0f, 1f) > 0.5f ? -5 : 5
            );

        Target target = targetObject.GetComponent<Target>();
        target.onHitFloor = () =>
        {
            isGameOver = true;
        };
    }
}
