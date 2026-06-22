using UnityEngine;
using UnityEngine.InputSystem;

public class RunnerPlayerController : MonoBehaviour
{
    private Rigidbody runnerRb;
    public InputAction jumpAction;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        runnerRb = GetComponent<Rigidbody>();
        jumpAction.Enable();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && isOnGround)
        {
            runnerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }

    }
}
