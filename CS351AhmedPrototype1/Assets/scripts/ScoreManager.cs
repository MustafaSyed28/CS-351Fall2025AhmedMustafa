using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// add this to work with text with TextMeshPro
using TMPro;
// Add to work with SceneManager
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;


    // set this in the inspector
    public TMP_Text textbox;

    public int scoreToWin;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }
        if (score >= scoreToWin)
        {
            won = true;
            gameOver = true;
        }


        if (gameOver)
        {
            if (won)
            {
                // display win text
                textbox.text = "You Win!\n Press R to try Again!";
            }
            else
            {
                // display lose text
                textbox.text = "You Lose!\n Press R to try Again!";

            }

            // if they press R key Relode scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }

    }   
    
}
