using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class EggPlayerController : MonoBehaviour
{
    public float eggPlayerSpeed = 150f;
    public bool hasPowerUp;
    public GameObject powerUpIndicator;
    private float powerUpStrenght = 15.0f;
    private InputSystem_Actions controls;
    private Rigidbody eggPlayerRb;
    private GameObject focalPoint;
    

    void Awake()
    {
        controls = new InputSystem_Actions();
        eggPlayerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float forwardInput = moveInput.y;
        eggPlayerRb.AddForce(focalPoint.transform.forward * forwardInput * eggPlayerSpeed * Time.deltaTime);
        powerUpIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7.0f);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            
            Debug.Log("Collided with " + collision.gameObject.name + " with power-up set to " + hasPowerUp);
            enemyRb.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
        }
    }
}
