using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{

    Block[] electricBlocks;
    [SerializeField] GameSession gameSession;

    int totalBlocksToBreak = 0;
    int totalBlocksBroken = 0;

    int totalPlayerScore;

    void Awake()
    {
        Debug.Log("In Awake() on " + transform.name);
        //determine the number of gamesession instances
        //if we aren't the onmly one, destroy ourselves
        if (FindObjectsOfType<LevelHandler>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            //we are first, stay between scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        electricBlocks = FindObjectsOfType<Block>(); //get all of the electric blocks available
        Debug.Log("Found: " + electricBlocks.Length + " blocks...");
        if(electricBlocks != null) //gameover/start menu ignore
        {
            processBlocksForLevel();
        }
       
    }

    private void processBlocksForLevel() //process the blocks by sorting breakable and unbreakable
    {
        for(int i = 0; i < electricBlocks.Length; i++)
        {
            if(!electricBlocks[i].isBlockBreakable())
            {
                totalBlocksToBreak = totalBlocksToBreak + 1;
            }
        }
                   Debug.Log("Found block " + totalBlocksToBreak + " to be unbreakable");
    }

    public void onBlockDestroy(GameObject gameObject) //called from onDestroy from Block.cs
    {
        Debug.Log("Processing block destroyed... ");
        for (int i = 0; i < electricBlocks.Length; i++)
        {
            if (!electricBlocks[i].isBlockBreakable())
            {
                int storedBlockID = electricBlocks[i].getBlockID();
                int destroyedBlockID = ((Block)gameObject.GetComponent<Block>()).getBlockID();

                if (storedBlockID == destroyedBlockID) //we check to make sure the blockID values are the same so we can determine between each block instance
                {
                    totalBlocksToBreak = totalBlocksToBreak - 1;
                    totalPlayerScore += electricBlocks[i].getBlockPointValue();
                   
                    Debug.Log("Breakable block has been broken (" + totalBlocksToBreak + " left to break). Total Player Points: " + totalPlayerScore);
                    gameSession.addPlayerPoints(electricBlocks[i].getBlockPointValue());

                    if (totalBlocksToBreak == 0) //we broke all the blocks lets finish the game or move on next level
                    {
                        gameSession.levelCompleted(); //let our gameSession know level is compeleted, move to next level
                        Debug.Log("Game Level Completed");
                    }
                }
            } else
            {
                Debug.Log("Continueing out because either block is unbreakable or already broken");
                continue;
            }
        }
    }
}
