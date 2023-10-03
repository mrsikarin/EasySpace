using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;


    void Awake()
    {
        instance = this;
    }
 
    public void TakeDamage()
    {

    }


}


