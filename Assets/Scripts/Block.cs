using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public AudioSource bounceSound;
    [SerializeField] private int blockPointValue = 15;

    //particles effect
    [SerializeField] GameObject ParticlesVFX;

    //extra points for block hits to destroy
    private int amountBlockHasBeenHit = 1;
    [SerializeField] private int blockHitsToDestroy = 1;
    [SerializeField] private bool unbreakableBlock = false;
    [SerializeField] LevelHandler levelHandler;
    private int blockID;

    // Start is called before the first frame update
    void Start()
    {
        bounceSound = GetComponent<AudioSource>(); //initiate bounce sound when block gets hit
        blockID = Random.Range(1, 1500);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bounceSound.Play(); //play sound when collision happens on electric block

   
        if (!unbreakableBlock && amountBlockHasBeenHit >= blockHitsToDestroy) //dont destroy except after x amount of hits and only if block is breakable
        {

            Debug.Log(gameObject.name + " has colided with " + collision.gameObject.name);
            levelHandler.onBlockDestroy(gameObject); //notify levelhandler this block has been destroyed
            Debug.Log("Notifying levehandler block has been broken...");

            //create our particle effects on destroy
            GameObject explosionVFX = Instantiate(ParticlesVFX, transform.position, transform.rotation);
            Destroy(explosionVFX, bounceSound.clip.length);

            Destroy(gameObject, bounceSound.clip.length); //destroy the game object on hit and after sound played
        } else
        {
            amountBlockHasBeenHit++;
            Debug.Log("This is a special block that needs to be hit: " + blockHitsToDestroy + " times to destroy, already hit it: " + amountBlockHasBeenHit + " times");
        }
    }


    public int getBlockPointValue() //our getter for getting the block point value
    {
        return blockPointValue;
    }

    public bool isBlockBreakable() //our getter for checking if this block is breakable
    {
        return unbreakableBlock;
    }

    public int getBlockID()
    {
        return blockID;
    }
}

