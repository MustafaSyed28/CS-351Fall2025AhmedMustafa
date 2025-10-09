using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;

    public AudioClip scoreSound;

    private AudioSource playerAudio;

    private void Start()
    {

        // set reference to audio source – be sure to add this component
        playerAudio = GetComponent<AudioSource>();
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (active && collision.gameObject.tag == "Player")
        {
            active = false;

            // Add 1 to the score when the player enter trigger zone
            ScoreManager.score++;

            playerAudio.PlayOneShot(scoreSound, 1.0f);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;

            Destroy(gameObject, 2.0f);
        }


    }
}
