using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AITextField : MonoBehaviour
{
    Text AiGuessText;

    void Start()
    {
        AiGuessText = GetComponent<Text>(); //grab the component
    }

    public void SetAIGuess(int aiGuessCount)
    {
        AiGuessText.text = aiGuessCount.ToString();
        Debug.Log("Setting AI Guess... " + aiGuessCount);
    }
}
