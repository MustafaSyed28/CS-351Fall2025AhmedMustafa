using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (active && collision.gameObject.tag == "Player")
        {
            active = false;

            // Add 1 to the score when the player enter trigger zone
            ScoreManager.score++;

            Destroy(gameObject);
        }


    }
}
