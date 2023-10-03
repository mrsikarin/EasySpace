using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Camera mainCamera;
void Start()
{
    mainCamera = Camera.main;
    Debug.Log(mainCamera.ViewportToWorldPoint(Vector2.zero).x+ " : "+ mainCamera.ViewportToWorldPoint(Vector2.zero).y);
}
}
