using UnityEngine;

public class SpawnManagerProject3 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25f, 0f, 0f);
    private float startDelay = 2f;
    private float repeatRate = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
