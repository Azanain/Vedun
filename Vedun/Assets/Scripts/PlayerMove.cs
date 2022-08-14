using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float testAngle;

    private Rigidbody rb;
    private ThrowExe throwExe;
    private Vector3 moveInput;

    [HideInInspector] public Vector3 target;

    public static Vector3 myPosition { get; private set; }
    private void Awake()
    {
        throwExe = GetComponent<ThrowExe>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        transform.LookAt(moveInput + transform.position);
        myPosition = transform.position;

        if (target != Vector3.zero)
        {
            Rotate();
        }
    }
    private void Move()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = moveInput * moveSpeed;
    }
    public void Rotate()
    {
        Vector3 direction = new Vector3(target.x, 0f, target.z) - new Vector3(transform.position.x, 0, transform.position.z);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);

        Vector3 targetDir =target - transform.position;
        Vector3 forward = transform.forward;

        float angleBetween = Vector3.SignedAngle(targetDir.normalized, forward.normalized, Vector3.forward.normalized);

        if (Mathf.Abs(angleBetween) <= testAngle)
        {
            throwExe.Throw();
            target = Vector3.zero;
        }
    }
}
