using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.GetSphere();
            Destroy(transform.parent.gameObject);
        }
    }
}
