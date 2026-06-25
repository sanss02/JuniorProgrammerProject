using UnityEngine;

public class EnemyGhostShell : MonoBehaviour
{
    public float enemySpeed = 3.0f;
    private Rigidbody enemyGShellRb;
    private GameObject eggPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyGShellRb = GetComponent<Rigidbody>();
        eggPlayer = GameObject.Find("EggPlayer");   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = eggPlayer.transform.position - transform.position.normalized;
        enemyGShellRb.AddForce(lookDirection * enemySpeed);
        
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
