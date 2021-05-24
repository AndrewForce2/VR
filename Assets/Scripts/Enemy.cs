using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private bool prefabIndex;

    // Start is called before the first frame update
    void Start()
    {
        prefabIndex = Random.Range(0f, 1f) > 0.5f;
        enemyPrefabs[prefabIndex ? 0 : 1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
