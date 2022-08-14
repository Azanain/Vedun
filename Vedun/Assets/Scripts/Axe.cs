using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class Axe : MonoBehaviour
{
    [SerializeField] private float durationThwor;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float timeDelayMoveBack;

    private Animator animator;
    private PoolObject poolObject;
    private Transform player;
    public int NumberImpoveAxe { get; private set; }

    private void Start()
    {
        EventManager.UpgradeAxeEvent += UpgradeAxe;
        EventManager.AxeComeBackEvent += AxeComeBack;
        poolObject = GetComponent<PoolObject>();
        animator = GetComponent<Animator>();
        animator.speed = rotateSpeed;
        NumberImpoveAxe = ThrowExe.NumberImpoveAxe;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnEnable()
    {
        StartCoroutine(Throw());
    }
    private IEnumerator Throw()
    {
        float timer = 0;
        float progress = 0;
        while (progress < 1)
        {
            timer += Time.deltaTime;
            progress = timer / durationThwor;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            yield return null;
        }
        if (timer >= 1)
        {
            yield return new WaitForSeconds(timeDelayMoveBack);
            StopCoroutine(Throw());
        }
    }
    private void AxeComeBack()
    { 
         StartCoroutine(Back());
    }
    private IEnumerator Back()
    {
        animator.SetTrigger("Back");
        while (!PlayerControl.CanThrowAxe)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.LookAt(player);
            yield return null;
        }
        if (PlayerControl.CanThrowAxe)
            StopCoroutine(Back());
    }
    private void UpgradeAxe()
    {
        NumberImpoveAxe++;
    }
    private void DestroyBullet()
    {
        poolObject.ReturnToPool();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyBullet();
        }
    }
    private void OnDestroy()
    {
        EventManager.AxeComeBackEvent -= AxeComeBack;
        EventManager.UpgradeAxeEvent -= UpgradeAxe;
    }
}
