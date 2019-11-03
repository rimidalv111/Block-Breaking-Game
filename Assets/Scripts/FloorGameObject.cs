using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGameObject : MonoBehaviour
{

    //load the sceneloader object
    [SerializeField] SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The " + other.gameObject.name + " has collided with the floor, so we lost!");
        sceneLoader.LoadWinScene(); //load the win/lost scene
    }
}
