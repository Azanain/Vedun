using UnityEngine;

public class TriggetBridge : MonoBehaviour
{
    [SerializeField] private int needImproveAxe;

    private Bridge bridge;

    private void Awake()
    {
        bridge = GetComponentInParent<Bridge>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {
            int improve = other.GetComponent<Axe>().NumberImpoveAxe;

            if (improve >= needImproveAxe)
                bridge.BrokeChain();
            else
                EventManager.MessageNeedMorePower();
        }
    }
}
