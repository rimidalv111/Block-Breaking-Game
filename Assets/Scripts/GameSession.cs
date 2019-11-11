using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    //load the sceneloader object
    [SerializeField] SceneLoader sceneLoader;
    //sound played on level complete
    [SerializeField] AudioSource levelCompleteSound;

    private int currentLevel = 0;
    private int numberOfScenes;
    private int numberOfLevels;
    private bool completedLevel;

    private int playerPoints = 0;

    //player score
    [SerializeField] private Text scoreText;

    void Awake()
    {
        Debug.Log("In Awake() on " + transform.name);
        //determine the number of gamesession instances
        //if we aren't the onmly one, destroy ourselves
        if(FindObjectsOfType<GameSession>().Length > 1)
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

    // Update is called once per frame
    void Start()
    {
        //capture how many scenes we have (including any new ones added to build)
        numberOfScenes = SceneManager.sceneCountInBuildSettings;

        Debug.Log("It seems there are total of: " + numberOfScenes + " secenes available to play");

        //do the calculations to find the total number of levels ignoring start scene and game over scene
        if (numberOfScenes > 2) //acounting for 0 in array list as first level...
        {
            numberOfLevels = numberOfScenes - 2; //how many game levels do we actually have loaded
            Debug.Log("We have loaded: " + numberOfLevels + " levels to play!");

            currentLevel = 1; //start on the first level because it exists
        } else
        {
            Debug.Log("It seems there is not a single level loaded...");
            finishGameSession(true); //finish the game session since there are no levels
        }

        //initiate the levelcomplete sound
        levelCompleteSound = GetComponent<AudioSource>();

    }

    private void Update()
    {
        displayPlayersScore(); //always display the players current score
    }

    public void levelCompleted() //this runs before loadNextLevel() to confirm level completion
    {
        currentLevel++; //increase level

        Debug.Log("Next Level: " + currentLevel);
        //play sound on level complete
        levelCompleteSound.Play();


        if (currentLevel <= numberOfLevels) //make sure we load available levels
        {
            loadNextLevel(currentLevel); //load the next level if one is available
            GameObject.Destroy(GameObject.Find("LevelHandler")); //destroy the old level handler, create new one for each new level
            GameObject.Instantiate(GameObject.Find("LevelHandler"));     //update level handler to load new blocks 
        }
        else
        {
            finishGameSession(true);
        }
    }

    public void loadNextLevel(int levelid)
    {
        Debug.Log("We are loading the next level..");
        sceneLoader.LoadLevelScene(levelid); //load next level if any
    }

    public void finishGameSession(bool lost)
    {
        if(!lost) //we didn't lose so play a winning tune
        {
            levelCompleteSound.Play();
        }

        //load game over 
         Debug.Log("You lost the game or won all of the levels!");
        sceneLoader.LoadLevelScene(numberOfScenes - 1); //load game over scene
    }

  
    //this logic is the support of players points gained on screen display
    public void displayPlayersScore() //run on update();
    {
        scoreText.text = "SCORE: " + playerPoints;
    }

    public void addPlayerPoints(int amount) //add player points
    {
        playerPoints = playerPoints + amount;
    }

    public int getPlayerPoints() //getter player points
    {
        return playerPoints;
    }
}
