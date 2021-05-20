using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start(){
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>(); 
    }


    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            PlayerMovement pm = playerMovement;
            bool isPlayerImmune = pm.immunity;
            if(!isPlayerImmune)
                playerMovement.KillPlayer();
            else {
                playerMovement.ImmunityOff();
            }
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
