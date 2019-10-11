using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] int initalLowerBound = 1;
    [SerializeField] int initialUpperBound = 1000;


    int AICount; //our current AI guess
    [SerializeField] int lowerBound = 1; //use these to store the direction of the guess
    [SerializeField] int higherBound = 1000; // for ex. are we guessing higher numbers or lower numbers

    AITextField scriptHandle; //our aitextfield

    [SerializeField] GameObject aiGuessObject;

    void Start()
    {
        AICount = randomGuesss(initalLowerBound, initialUpperBound); //get a random number in our initial bounds

        scriptHandle = (AITextField)aiGuessObject.GetComponent(typeof(AITextField)); //connect to our text component

        scriptHandle.SetAIGuess(AICount); //update our first guess
    }

    public void StartGame()
    {
        Debug.Log("Start Game was invoked");
    }

    public void GuessHigher()
    {
        Debug.Log("Higher button was pressed");

        //logic for saving lowerBound for narrrowing down guessed number; is done when the player hits 'guess higher'
        if (AICount > lowerBound) 
        {
            lowerBound = AICount;
        }
        if (lowerBound >= higherBound) //we dont want our lowerBound to be higher than our higherBound.
        {
            lowerBound = initalLowerBound;
        }

        nextGuess(AICount, higherBound); //output our next guess using our current saved boundaries

    }

    public void GuessLower()
    {
        Debug.Log("Lower button was pressed");

        //logic for saving higherBound for narrrowing down guessed number; is done when the player hits 'guess lower'
        if (AICount < higherBound)
        {
            higherBound = AICount;
        }
        if (higherBound <= lowerBound) //we don't want our higherBound to be lower than the lowerBound
        {
            higherBound = initialUpperBound;
        }

        nextGuess(lowerBound, AICount); //output our next guess using our current saved boundaries
    }

    public void nextGuess(int one, int two)
    {
        Debug.Log("Our Next Guess Range: " + one + " R2: " + two);
        if(one == two) //the end of our cycle is reached so repeat it using initial variables
        {
            nextGuess(initalLowerBound, initialUpperBound);
            Debug.Log("Should see it repeating");
        }   else
        {
            AICount = randomGuesss(one, two); //get a random number in our bounds whatever they maybe

            scriptHandle.SetAIGuess(AICount); //update our next guess
        }
    }

    public int randomGuesss(int one, int two)
    {
        int num = Random.Range(one, two + 1); //random guess from our bounds (we +1 since upperBound is exclusive)
        return num;
    }
}
