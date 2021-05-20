using UnityEngine;

public class CoinSpeed : MonoBehaviour // actually immunity coin
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

        playerMovement.immunity = true;

        Destroy(gameObject);
    }
}
