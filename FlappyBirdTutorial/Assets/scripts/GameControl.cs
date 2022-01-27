using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;

    private int score = 0; 
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    // Start is called before the first frame update
    void Awake()    
    {
        if(instance == null)
        {
            instance = this; 
        }
        else if(instance != this)
        {
            Destroy(gameObject); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return; 
        }

        score++;
        scoreText.text = "SCORE: " + score.ToString(); 
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true); 
        gameOver = true; 
    }
}
