using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGameObject : MonoBehaviour
{

    //load the sceneloader object
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameSession gameSession; //load gamesession

    public AudioSource gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        gameOverSound = GetComponent<AudioSource>(); //initiate gameover sound when block gets hit
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The " + other.gameObject.name + " has collided with the floor, so we lost!");
        gameOverSound.Play();

        Invoke("gameSessionOver", 4); // play the 'you lost' sound before ending the game session and moving to next scene
    }

    void gameSessionOver()
    {
        gameSession.finishGameSession(true); // let our game session know we lost, not won the level
    }
}
