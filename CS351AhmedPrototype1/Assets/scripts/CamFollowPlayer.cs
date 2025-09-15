using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    // set this reference in the inspector
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // set position of cam to player position
        transform.position = new Vector3 (
        player.transform.position.x,
        player.transform.position.y,
        transform.position.z);
    }
}
