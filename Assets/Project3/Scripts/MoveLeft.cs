using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private RunnerPlayerController runnerPlayerControllerScript;
    private float leftBound = -9.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        runnerPlayerControllerScript = GameObject.Find("RunnerPlayer").GetComponent<RunnerPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (runnerPlayerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
