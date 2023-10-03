using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveInScreen : MonoBehaviour
{
    public static CanMoveInScreen instance;
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    public Vector2 minPos;
    public Vector2 maxPos;
    Camera mainCamera;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
                mainCamera = Camera.main;
        minPos = new Vector2(mainCamera.ViewportToWorldPoint(Vector2.zero).x + minXOffset, mainCamera.ViewportToWorldPoint(Vector2.zero).y + minYOffset);
        maxPos = new Vector2(mainCamera.ViewportToWorldPoint(Vector2.right).x - maxXOffset, mainCamera.ViewportToWorldPoint(Vector2.up).y - maxYOffset);

    }
    void Start()
    {


    }
    public Vector2 GetMinScreenPosition()
    {

        return minPos;
    }
    public Vector2 GetMaxScreenPosition()
    {
        return maxPos;
    }
}
