 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

 public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    private int score;
    void Start()
    {
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddScore()
    {
        score += 5;
        scoreText.text = "Score: " + score;
    }
    
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public int getScore()
    {
        return score;
    }
    
    
    
    
    
}
