using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    // a float to hold the speed of out tank player
    // try setting this to 8 in the inspect
    public float speed;


    // a float for our turn speed
    // Start is called before the first frame update
    public float turnSpeed;


    // variables for input
    public float horizontalInput;
    public float verticalInput;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // moving forward
        //transform.Translate(1, 0, 0);

        //this do the same
        //transform.Translate(Vector3.right);

        //transform.Translate(Vector3.right * Time.deltaTime * speed);

        // get input in update()
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // move player forward with vertical input
        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        // rotate player with horizontal input
        //transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);

        // rotate player with horizontal input but reverse the rotation direction when moving backwards
        if (verticalInput < 0)
        {
            transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime * horizontalInput);
        }
        else
        {
            transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);
        }


    }
}
