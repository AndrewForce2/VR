using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropContainer : MonoBehaviour
{
    public GameObject[] propPrefabs;
    public int amountOfProps = 5;
    public Transform[] targetSpawnPoints;

    private List<Transform> spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        //Intialize availableSpawnPoints Intdexes
        List<int> availableIndexes = new List<int>();
        for (int i = 0; i < propPrefabs.Length; i++)
        {
            availableIndexes.Add(i);
        }

        spawnPoints = new List<Transform>();

        foreach (Transform spawnPoint in transform.GetComponentInChildren<Transform>()) {
            if(spawnPoint != this.transform)
            {
                spawnPoints.Add(spawnPoint);
            }
        }
        for(int i = 0; i < amountOfProps; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            int propIndex = availableIndexes[Random.Range(0, availableIndexes.Count)];

            availableIndexes.Remove(propIndex);

            GameObject addedProp = Instantiate(propPrefabs[propIndex]);
            addedProp.transform.name = propPrefabs[propIndex].name;
            addedProp.transform.position = spawnPoint.transform.position;
            addedProp.transform.tag = "TargetProp";

            GameObject targetProp = Instantiate(propPrefabs[propIndex]);
            targetProp.transform.position = targetSpawnPoints[i].transform.position;

            spawnPoints.Remove(spawnPoint);

        }
        //Fill the game with other props
        int remainingSpawnPoints = spawnPoints.Count;
        for(int i = 0; i < remainingSpawnPoints; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            int propIndex = availableIndexes[Random.Range(0, availableIndexes.Count)];

            GameObject addedProp = Instantiate(propPrefabs[propIndex]);
            addedProp.transform.name = propPrefabs[propIndex].name;
            addedProp.transform.position = spawnPoint.transform.position;

            spawnPoints.Remove(spawnPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
