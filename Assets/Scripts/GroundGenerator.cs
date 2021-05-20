using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool generateItems){
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity); // generate an object(what, where, rotation(no))       
        nextSpawnPoint = temp.transform.GetChild(1).transform.position; 

        if (generateItems){
            temp.GetComponent<GroundTile>().GenerateRandomObstacle();
            temp.GetComponent<GroundTile>().GenerateCoin();
        }
    }

    //Start is called before the first frame update
    void Start(){
        for (int i = 0; i < 15; i++){
            if(i < 5)
                SpawnTile(false);
             else 
                SpawnTile(true);
        }
    }
}