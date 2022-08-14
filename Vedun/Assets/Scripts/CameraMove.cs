using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetZ;
    private Vector3 playerPosition;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        playerPosition = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + 10, player.transform.position.z + offsetZ);
        Vector3 currentPosition = Vector3.Lerp(transform.position, playerPosition, speed * Time.deltaTime);
        transform.position = currentPosition;
    }
}
