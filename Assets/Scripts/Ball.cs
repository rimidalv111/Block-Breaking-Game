using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float InitialBallVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Pressed primary button.");
            LaunchBall(InitialBallVelocity);
        }
    }

    //method to launch the onject with a given (passed) velocity v
    private void LaunchBall(float v)
    {
        //get the handle to the rigidbody on the object this is attached to (the ball)
        Rigidbody2D ballRigidBody2D = GetComponent<Rigidbody2D>();
        //add y velocity to te object, none horizontally, and using the caller value on the y axis
        ballRigidBody2D.velocity = new Vector2(0, v);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " has colided with " + collision.gameObject.name);
    }
}
