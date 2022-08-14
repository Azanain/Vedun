using System.Collections;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject sphere;

    private GameObject box;
    private FixedJoint joint;
    private bool isSphereActive;
    private void Awake()
    {
        box = GameObject.Find("Box");
        joint = box.GetComponent<FixedJoint>();
    }
    public void CreateSphere()
    {
        Instantiate(sphere, box.transform.position, Quaternion.identity);
        isSphereActive = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe") && !isSphereActive)
        {
            StartCoroutine(DestroyBox());
        }
    }
    private IEnumerator DestroyBox()
    {
        joint.connectedBody = null;
        box.GetComponent<BoxCollider>().isTrigger = true;
        CreateSphere();
        yield return new WaitForSeconds(1f);
        Destroy(box);
        StopCoroutine(DestroyBox());
    }
}
