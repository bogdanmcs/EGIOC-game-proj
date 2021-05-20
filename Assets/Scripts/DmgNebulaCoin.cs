using UnityEngine;

public class DmgNebulaCoin : MonoBehaviour
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

        GameManager.inst.DecreaseScore();
        playerMovement.Nebula();

        Destroy(gameObject);
    }

    // Update is called once per frame
}
