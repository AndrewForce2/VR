using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{
    public TextMesh infoText;
    public GameObject kartPrefab;
    public float speed = 0.25f;
    public bool checkpoint;
    
    private int currentCheckpoint;
    private int currentLap;

    public int CurrentLap { get { return currentLap; } }
    // Start is called before the first frame update
    void Start()
    {
        currentCheckpoint = 0;
        currentLap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(
                Camera.main.transform.forward.x,
                0,
                Camera.main.transform.forward.z
            );
        transform.position += direction * speed * Time.deltaTime;

        kartPrefab.transform.eulerAngles = new Vector3(
                kartPrefab.transform.eulerAngles.x,
                Camera.main.transform.eulerAngles.y,
                kartPrefab.transform.eulerAngles.z
            );

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            int checkpoint = int.Parse(other.name);
            StartCoroutine(Checkpoint());
            if (checkpoint == currentCheckpoint + 1)
            {
                currentCheckpoint++;
            }

            if (checkpoint == 1 && currentCheckpoint == 4)
            {
                currentCheckpoint = 0;
                currentLap++;
            }
        }

        IEnumerator Checkpoint()
        {
            checkpoint = true;
            infoText.text = "Checkpoint!" ;
            yield return new WaitForSeconds(2f);
            checkpoint = false;
        }
    }
}
