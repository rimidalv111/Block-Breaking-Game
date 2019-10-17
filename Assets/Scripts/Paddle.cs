using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 pos;
    private float mousePosInUnits;
    [SerializeField] int screenWidthInUnits = 16;
    [SerializeField] float paddleMinX = 1f;
    [SerializeField] float paddleMaxX = 15f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithMouse();
    }

    private void MoveWithMouse()
    {
        pos = new Vector2(transform.position.x, transform.position.y);
        mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        pos.x = Mathf.Clamp(mousePosInUnits, paddleMinX, paddleMaxX);
        transform.position = pos;
    }
}
