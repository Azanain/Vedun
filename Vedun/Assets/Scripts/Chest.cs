using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameObject sprite;
    private bool canShowButton;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = gameObject.transform.Find("SpriteButton").gameObject;
        sprite.SetActive(false);
    }
    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("E")) && canShowButton)
        {
            animator.SetTrigger("Open");
            sprite.SetActive(false);
            EventManager.UpgradeAxe();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var sphere = other.GetComponent<PlayerControl>().Sphere;
        if (other.CompareTag("Player") && sphere.activeSelf)
        {
            sprite.SetActive(true);
            canShowButton = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canShowButton = false;
        }
    }
}
