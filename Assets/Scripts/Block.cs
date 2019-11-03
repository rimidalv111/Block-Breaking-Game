using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public AudioSource bounceSound;

    // Start is called before the first frame update
    void Start()
    {
        bounceSound = GetComponent<AudioSource>(); //initiate bounce sound when block gets hit
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        bounceSound.Play(); //play sound when collision happens on electric block

        Debug.Log(gameObject.name + " has colided with " + collision.gameObject.name);

        Destroy(gameObject, bounceSound.clip.length); //destroy the game object on hit and after sound played

    }
}

