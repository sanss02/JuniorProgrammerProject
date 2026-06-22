using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private RunnerPlayerController runnerPlayerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        runnerPlayerControllerScript = GameObject.Find("Player").GetComponent<RunnerPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (runnerPlayerControllerScript.gameObject == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
    }
}
