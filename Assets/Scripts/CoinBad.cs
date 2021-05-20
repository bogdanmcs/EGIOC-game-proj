using UnityEngine;

public class CoinBad : MonoBehaviour
{
        PlayerMovement playerMovement;

        void Start(){
            playerMovement = GameObject.FindObjectOfType<PlayerMovement>(); 
        }

       void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject);
            return;
        }

        if(other.gameObject.name != "Player"){
            return;
        }

        // jump high
        playerMovement.JumpAnyways();

        Destroy(gameObject);
    }
}
