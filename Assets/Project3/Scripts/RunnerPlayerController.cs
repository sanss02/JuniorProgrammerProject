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
    private Animator runnerPlayerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource runnerPlayerAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        runnerRb = GetComponent<Rigidbody>();
        jumpAction.Enable();
        Physics.gravity *= gravityModifier;
        runnerPlayerAnim = GetComponent<Animator>();
        runnerPlayerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && isOnGround && !gameOver)
        {
            runnerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            runnerPlayerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            runnerPlayerAudio.PlayOneShot(jumpSound, 1.0f);            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            runnerPlayerAnim.SetBool("Death_b", true);
            runnerPlayerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            runnerPlayerAudio.PlayOneShot(crashSound, 1.0f);
        }

    }
}
