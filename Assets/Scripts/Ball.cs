using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float InitialBallVelocity = 10f;
    [SerializeField] AudioClip wallBounceSound;
    [SerializeField] AudioClip paddleBounceSound;
    public AudioSource audio;

    private GameObject gamePaddle;
    private Vector2 GamePaddlePosition;
    private Vector2 InitalBallPosition;

    private bool isGameStarted = false;
    // Start is called before the first frame update
    void Start()
    {

        gamePaddle = GameObject.FindGameObjectWithTag("paddle"); //initiate paddle

        //grab audio sources
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!isGameStarted) //if game hasnt started yet keep the ball on the paddle
        {
            LockedPaddle();
        }
        if (Input.GetKey(KeyCode.Mouse0) && !isGameStarted) //start game when button is down
        {
            isGameStarted = true; //we start the game when we launch the ball up
            Debug.Log("Game started, launch ball up!");
            LaunchBall(InitialBallVelocity);
        }
    }

    //method to lock the ball onto the paddle until user starts the game by left clicking.
    private void LockedPaddle()
    {
        GamePaddlePosition = gamePaddle.transform.position; //get the paddle cords
        InitalBallPosition = transform.position; //get the initial ball position
        Vector2 positionOfPaddle = new Vector2(GamePaddlePosition.x, GamePaddlePosition.y + 0.5f); //set the ball in middle of paddle and above the paddle (not in the center of the y axis)
        transform.position = positionOfPaddle;
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
        if (isGameStarted) //we only want to play the sounds only when game is running
        {
            // when ball collides with ceiling, right wall, left wall, make sound
            if (collision.gameObject.name == "Ceiling" || collision.gameObject.name == "Right Wall" || collision.gameObject.name == "Left Wall")
            {
                audio.PlayOneShot(wallBounceSound, 0.7F);
            }
            //when ball collides with paddle make sound
            if (collision.gameObject.name == "Paddle")
            {
                audio.PlayOneShot(paddleBounceSound, 0.7F);
            }
            Debug.Log(gameObject.name + " has colided with " + collision.gameObject.name);
        }
    }
}
