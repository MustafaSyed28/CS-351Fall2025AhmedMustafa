using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnFall : MonoBehaviour
{

    // set this in the inspecter
    public float lowestY;

    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lowestY)
        {
            ScoreManager.gameOver = true;
        }
    }
}
