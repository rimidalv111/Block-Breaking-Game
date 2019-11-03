using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    public Vector2 startPos; //grab initial position
    private bool finished = false; //when finished update us

    GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position; //grab initial
        startButton = GameObject.FindGameObjectWithTag("StartButton");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 0) //move the image over to the right until it hits begining of screen
        {
            float newLocation = Mathf.Repeat(Time.time * 5f, 20);
            transform.position = startPos + Vector2.right * newLocation;
        }
    }
}
