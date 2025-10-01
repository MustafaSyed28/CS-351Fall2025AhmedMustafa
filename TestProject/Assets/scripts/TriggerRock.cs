using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class TriggerRock : MonoBehaviour
{
    [Header("Loop")]
    public Transform spawnPoint;             // If null, uses start position
    public float resetDelay = 0.35f;         // Wait before rock resets
    public float extraHeight = 0.0f;         // Add a bit of height on respawn if you want
    public bool randomizeDelay = false;
    public Vector2 randomDelayRange = new Vector2(0.2f, 0.8f);

    [Header("Ground Detection")]
    public LayerMask groundLayers;           // Assign "Ground" layer in Inspector

    [Header("Events")]
    public UnityEvent onHitPlayer;           // Drag any action (show text, respawn, etc.)

    Rigidbody2D rb;
    Vector3 startPos;
    bool resetting;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = (spawnPoint != null) ? spawnPoint.position : transform.position;

        // Good defaults for a falling rock
        rb.freezeRotation = true;            // keep circle upright
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 1) If we hit the Player -> fire event immediately
        if (collision.collider.CompareTag("Player"))
        {
            onHitPlayer?.Invoke();
            // You can also reset the rock after hitting the player if desired:
            if (!resetting) StartCoroutine(ResetAfterDelay());
            return;
        }

        // 2) If we hit the ground -> schedule a reset
        if (IsInLayerMask(collision.collider.gameObject.layer, groundLayers))
        {
            if (!resetting) StartCoroutine(ResetAfterDelay());
        }
    }

    System.Collections.IEnumerator ResetAfterDelay()
    {
        resetting = true;

        float wait = resetDelay;
        if (randomizeDelay) wait = Random.Range(randomDelayRange.x, randomDelayRange.y);
        yield return new WaitForSeconds(wait);

        // Zero out physics and teleport back to spawn
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        Vector3 target = startPos + Vector3.up * extraHeight;
        transform.position = target;

        // Nudge to ensure it leaves the platform cleanly (optional)
        rb.Sleep();    // clear any residual contacts
        rb.WakeUp();

        resetting = false;
    }

    // Utility: check if a layer is in a layermask
    bool IsInLayerMask(int layer, LayerMask mask)
    {
        return (mask.value & (1 << layer)) != 0;
    }
}
