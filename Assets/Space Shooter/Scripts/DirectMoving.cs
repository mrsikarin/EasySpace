using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the attached object along the Y-axis with the defined speed
/// </summary>
public class DirectMoving : MonoBehaviour {

    [Tooltip("Moving speed on Y axis in local space")]
    public float speed;
    public bool canRemove;
    Vector2 min;
    void Start()
    {
        min = CanMoveInScreen.instance.GetMinScreenPosition();
    }
    //moving the object with the defined speed
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); 
        if(canRemove)
            CheckOnScreen();
    }
    public void CheckOnScreen()
    {
        Vector2 pos = transform.position;
        if(pos.y < min.y)
            Destroy(gameObject);
    }
}
