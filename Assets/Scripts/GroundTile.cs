using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundGenerator groundGenerator;

    // Start is called before the first frame update
    void Start(){
        groundGenerator = GameObject.FindObjectOfType<GroundGenerator>();
    }

    private void OnTriggerExit(Collider other){ 
        groundGenerator.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update(){
        
    }

    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    public GameObject dmgNebulaPrefab;
    public GameObject whiteDiscPrefab;
    public GameObject turqDiscPrefab;
    public GameObject obstacle2Prefab;
    public GameObject obstacleBoxPrefab;
    public GameObject obstacleBSPrefab;
    public GameObject obstacleLavaPrefab;
    public float obstacle2ChangeOfGen = 0.2f;
    public float obstacleBoxChangeOfGen = 0.90f;
    public float obstacleBSChangeOfGen = 0.5f;

    public void GenerateRandomObstacle(){
        GameObject obstacleGen = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random <  obstacle2ChangeOfGen){
            obstacleGen = obstacle2Prefab;
        } else if(random > obstacleBoxChangeOfGen){
            obstacleGen = obstacleBoxPrefab;
        } else if(random > 0.4f && random < 0.5f){
            obstacleGen = obstacleBSPrefab;
        } else if(random > 0.5f && random < 0.6f){
            obstacleGen = obstacleLavaPrefab;
        }

        int obstacleIndex = Random.Range(2, 5); // 2-4
        Transform spawnLoc = transform.GetChild(obstacleIndex).transform; // return transformed component(L,M,R)
        Instantiate(obstacleGen, spawnLoc.position, Quaternion.identity, transform); // destroy obstacle as well
    }

    private float cn=0.7f, cw=0.80f;
    public void GenerateCoin(){
        int generatedCoins = 1;
        GameObject theChosenCoin = coinPrefab;
        float random;
        for(int i = 0; i < generatedCoins; i++){
            random  = Random.Range(0f, 1f);
            if(random >= 0f && random < cn){
                // same
            }
            else if (random >= cn && random < cw)
                theChosenCoin = whiteDiscPrefab;
            else if (random >= cw && random < 0.85f)
                theChosenCoin = turqDiscPrefab;
            else if (random >= 0.85f && random < 1f)
                theChosenCoin = dmgNebulaPrefab;

            GameObject temp = Instantiate(theChosenCoin, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider){
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
        Random.Range(collider.bounds.min.y, collider.bounds.max.y),
        Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if(point != collider.ClosestPoint(point)){
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
