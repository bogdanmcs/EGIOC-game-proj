using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
    public float speed = 25;
	float defaultSpeed;
    public Rigidbody rigidBody;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    public bool isPlayerAlive = true;
    public bool immunity = false;

    GameManager gameManager;

    AudioSource source;
    void Start(){
		defaultSpeed = speed;
        source = GetComponent<AudioSource>();
        
        gameManager = GameObject.FindObjectOfType<GameManager>();
        DecreaseLife();
		IncreaseAliveTime();
    }

    private void FixedUpdate(){
        if(!isPlayerAlive)
            return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime; // direction * speed * defaultDeltaTime = 5 u/s forward
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier; // horizontal move, 0 if centered
        rigidBody.MovePosition(rigidBody.position + forwardMove + horizontalMove); // move to specified position
    }

    // Update is called once per frame
    void Update(){
        horizontalInput = Input.GetAxis("Horizontal"); // horizontal control
        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
		 if (Input.GetMouseButtonDown(0)){
			 Jump();
		 }
        if(transform.position.y < -5) { // fell off the platform => kill player
            KillPlayer();
        } 
    }



    public void KillPlayer(){
        isPlayerAlive = false;
        source.Play();
        Invoke("Restart", 3);
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restart game
    }

    public float jumpForce = 400f;
    public LayerMask groundMask;

    void Jump(){
        float playerHeight = GetComponent<Collider>().bounds.size.y;
        bool isPlayerOnGround = Physics.Raycast(transform.position, Vector3.down, (playerHeight/2) + 0.1f, groundMask);

        if(isPlayerOnGround)
            rigidBody.AddForce(Vector3.up * jumpForce);
    }

    public void JumpAnyways(){
        rigidBody.AddForce(Vector3.up * 1000f);
    }

    public void ImmunityOff(){
        Invoke("DestroyImmunity", 3);
    }

    void DestroyImmunity(){
        immunity = false;
    }

    void DecreaseLife(){
        if(gameManager.score <= 0)
            KillPlayer();
        else if (isPlayerAlive){
            gameManager.DecreaseLife2();
            Invoke("DecreaseLife", 1);
        }
    }

    public void Nebula(){
        speed = 10;
        Invoke("RestoreSpeed", 3);
    }

    void RestoreSpeed(){
        speed = defaultSpeed;
    }
	
	void IncreaseAliveTime(){
        if(gameManager.score > 0 && isPlayerAlive){
				gameManager.IncreaseAliveTime2();
				Invoke("IncreaseAliveTime", 1);
		}
    }
}
