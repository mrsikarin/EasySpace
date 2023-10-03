using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;
    public int maxhealth;
    public int Damage;
    public int health;
    public bool isShield;
    public float flickerDuration = 0.5f; 
    public float flickerInterval = 0.1f; 
    public SpriteRenderer spriteRenderer; 
    private bool isFlickering = false; 

    public static Player instance; 

    private void Awake()
    {
        if (instance == null) 
            instance = this;

        health = maxhealth;
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        if(isShield)
            return;
        if (isFlickering)
            return;
        StartCoroutine(FlickerPlayer());
        health = Mathf.Clamp(health - damage,0,maxhealth);
        if(health <= 0 )
        {
            Destruction();
        }
        
    }    
    private IEnumerator FlickerPlayer()
    {

        Color originalColor = spriteRenderer.color;
        isFlickering = true;
    
        float timeElapsed = 0f;
        bool isVisible = true;

        while (timeElapsed < flickerDuration)
        {

            if (isVisible)
            {
                spriteRenderer.color = Color.clear; 
            }
            else
            {
                spriteRenderer.color = originalColor; 
            }

            isVisible = !isVisible;

            timeElapsed += flickerInterval;
            yield return new WaitForSeconds(flickerInterval);
        }
        spriteRenderer.color = originalColor;
        isFlickering = false;
   
    }

    //'Player's' destruction procedure
    void Destruction()
    {
        GameManager.instance.onGameEnd();
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        Destroy(gameObject);
    }
    public void Heal(int value)
    {
        health = Mathf.Clamp(health + value,0,maxhealth);
    }
    public void AddDamage(int damage)
    {
        Damage += damage;
    }
    public void RemoveDamage(int damage)
    {
        Damage = Mathf.Clamp(Damage - damage,0,Damage);
    }
    public void OpenShield()
    {
        isShield = true;
    }
    public void CloseShield()
    {
        isShield = false;
    }
    public int GetHealth()
    {
        return health;
    }

}
















