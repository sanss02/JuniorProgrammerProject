using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX2 : MonoBehaviour
{
    public GameObject dogPrefab;
    public InputAction fireAction;
    public float fireRate = 0.55f;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (fireAction.triggered && Time.time > nextFire)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}