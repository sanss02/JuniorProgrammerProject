using UnityEngine;

public class DetectCollisionsX2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
