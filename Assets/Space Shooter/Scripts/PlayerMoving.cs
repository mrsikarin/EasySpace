﻿using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines the borders of ‘Player’s’ movement. Depending on the chosen handling type, it moves the ‘Player’ together with the pointer.
/// </summary>

[System.Serializable]
public class Borders
{
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class PlayerMoving : MonoBehaviour {

    [Tooltip("offset from viewport borders for player's movement")]
    public Borders borders;
    Camera mainCamera;
    bool controlIsActive = true; 

    public static PlayerMoving instance; //unique instance of the script for easy access to the script

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        ResizeBorders();                //setting 'Player's' moving borders deending on Viewport's size
    }

    private void Update()
    {
        if (controlIsActive)
        {
#if UNITY_STANDALONE || UNITY_EDITOR    //if the current platform is not mobile, setting mouse handling 

            if (Input.GetMouseButton(0)) //if mouse button was pressed       
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //calculating mouse position in the worldspace
                mousePosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, mousePosition, 30 * Time.deltaTime);
            }
#endif

#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile, 

            if (Input.touchCount == 1) // if there is a touch
            {
                Touch touch = Input.touches[0];
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);  //calculating touch position in the world space
                touchPosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, touchPosition, 30 * Time.deltaTime);
            }
#endif
            transform.position = new Vector3    //if 'Player' crossed the movement borders, returning him back 
                (
                Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
                Mathf.Clamp(transform.position.y, borders.minY, borders.maxY),
                0
                );
        }
    }

    //setting 'Player's' movement borders according to Viewport size and defined offset
    void ResizeBorders() 
    {
        Vector2 posMin = CanMoveInScreen.instance.GetMinScreenPosition();
        Vector2 posMax = CanMoveInScreen.instance.GetMaxScreenPosition();
    
        borders.minX = posMin.x; //mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = posMin.y;//mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = posMax.x;//mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = posMax.y;// mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
}
