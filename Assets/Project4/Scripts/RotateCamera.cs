using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float cameraRotationSpeed = 150f;
    private InputSystem_Actions controls;

    void Awake()
    {
        controls =  new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Player.Enable();
        Debug.Log(controls.Player.Move);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float horizontalInput = moveInput.x;
        transform.Rotate(Vector3.up, horizontalInput * cameraRotationSpeed * Time.deltaTime);
    }
}
