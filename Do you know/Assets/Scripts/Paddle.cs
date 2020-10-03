using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config param
    [SerializeField] float screenUnits = 16f;
    [SerializeField] float minPosition = 1;
    [SerializeField] float maxPosition = 16;

    //Cash references
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, 0.6f);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minPosition, maxPosition);
        transform.position = paddlePosition;
        
    }

    private float GetXPos()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenUnits;
        }
    }
}
