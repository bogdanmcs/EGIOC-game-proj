using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject);
            return;
        }

        if(other.gameObject.name != "Player"){
            return;
        }

        GameManager.inst.IncreaseScore();

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update(){
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
