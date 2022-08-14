using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerMove playerMove;
    public static bool CanThrowAxe { get; private set; } = true;
    public GameObject Sphere { get; private set; }
    
    [SerializeField] private GameObject axeObj;

    private void Awake()
    {
        EventManager.UpgradeAxeEvent += UpgradeAxe;
        EventManager.GetSphereEvent += GetSphere;
        EventManager.ThrewAxeEvent += ThrewAxe;
        playerMove = GetComponent<PlayerMove>();
        Sphere = gameObject.transform.Find("sphereObj").gameObject;
        Sphere.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100) && CanThrowAxe)
            {
                playerMove.target = hit.point;
            }
        }
        if (Input.GetMouseButtonDown(1) && !axeObj.activeSelf)
            EventManager.AxeComeBack();
    }
    private void GetSphere()
    {
        if (!Sphere.activeSelf)
            Sphere.SetActive(true);
    }
    private void UpgradeAxe()
    {
        Sphere.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        { 
            CanThrowAxe = true;
            axeObj.SetActive(true);
        }
    }
    private void ThrewAxe(bool isThrew)
    {
        CanThrowAxe = isThrew;

        if (!CanThrowAxe)
            axeObj.SetActive(false);
        else
            axeObj.SetActive(true);
    }
    private void OnDestroy()
    {
        EventManager.ThrewAxeEvent -= ThrewAxe;
        EventManager.GetSphereEvent -= GetSphere;
        EventManager.UpgradeAxeEvent -= UpgradeAxe;
    }
}
