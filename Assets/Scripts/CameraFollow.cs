using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start(){
        offset = transform.position - player.position; // stable camera distance from player
    }

    // Update is called once per frame
    void Update(){
        Vector3 targetPosition = player.position + offset;
        targetPosition.x = 0; // don't move camera upon horizontal movement
        transform.position = targetPosition;
    }
}
