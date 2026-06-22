using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public InputAction movePlane; //Variable que lee la entrada que ingresa el usuario
    private float verticalInput; //Variable que lee el valor de la entrada del usuario

    //
    void OnEnable()
    {
        movePlane.Enable();   
    }


    // Start is called before the first frame updates
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = movePlane.ReadValue<float>();

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
    }
}
