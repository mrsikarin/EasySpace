using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
    public GameObject Projectile;
    public float ProjectileSpeed;

    public int shotChance;
    public float shotTimeMin, shotTimeMax;
    private void Start()
    {
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
    }
    void ActivateShooting() 
    {
        if (Random.value < (float)shotChance / 100)                             //if random value less than shot probability, making a shot
        {                         
            Projectile bullet = Instantiate(Projectile,  gameObject.transform.position, Quaternion.identity).GetComponent<Projectile>();  
            bullet.GetComponent<DirectMoving>().speed = ProjectileSpeed;
            bullet.damage = Damage;           
        }
    }

}
