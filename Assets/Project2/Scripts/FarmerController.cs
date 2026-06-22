using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerController : MonoBehaviour
{
    public InputAction moveFarmerAction;
    public Vector2 moveFarmerInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;
    public InputAction fireAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveFarmerAction.Enable();
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        moveFarmerInput = moveFarmerAction.ReadValue<Vector2>();
        transform.Translate(Vector3.right * moveFarmerInput * Time.deltaTime * speed);

        if (fireAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
