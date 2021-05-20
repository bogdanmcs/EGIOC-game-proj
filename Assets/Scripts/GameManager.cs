using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 10;
	int aliveSeconds = 0;
    public static GameManager inst;

    public Text scoreText;
	public Text aliveText;

    private void Awake(){
        inst = this;
    }

    public void IncreaseScore(){
        score += 2;
        scoreText.text = "LIFE: " + score; 
    }

    // Start is called before the first frame update
    
    public void DecreaseLife2(){
        if(score > 0){
            score--;
            scoreText.text = "LIFE: " + score;
        } else {
            score = -77;
        }
    }

    public void DecreaseScore(){
        if(score > 5){
            score -= 5;
            scoreText.text = "LIFE: " + score; 
        } else {
            score = -77;
            scoreText.text = "LIFE: 0";
        }
    }
	
	public void IncreaseAliveTime2(){	
		aliveSeconds++;
		aliveText.text = "ALIVE(s): " + aliveSeconds; 
	}
	
	public int GetAliveSeconds(){
		return aliveSeconds;
	}
}
