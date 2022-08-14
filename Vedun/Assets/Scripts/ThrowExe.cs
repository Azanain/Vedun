using UnityEngine;

public class ThrowExe : MonoBehaviour
{
    [SerializeField] private Transform firePosition;

    private Pool pool;

    public static int NumberImpoveAxe { get; private set; } = 1;

    private void Awake()
    {
        EventManager.UpgradeAxeEvent += UpgradeAxe;
        pool = GetComponent<Pool>();
    }
    private void Start()
    {
        EventManager.UpdateTextImprove(NumberImpoveAxe);
    }
    private void UpgradeAxe()
    {
        NumberImpoveAxe++;
        EventManager.UpdateTextImprove(NumberImpoveAxe);
    }
    public void Throw()
    {
        EventManager.ThrewAxe(false);
        pool.GetFreeElement(firePosition.position, firePosition.rotation);
    }
    private void OnDestroy()
    {
        EventManager.UpgradeAxeEvent -= UpgradeAxe;
    }
}
