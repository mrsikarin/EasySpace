using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PowerUp/PowerHeal",fileName ="new PowerHeal")]
public class PowerHeal : PowerUp
{
    public int health;
    public override void Active()
    {
        base.Active();
        Player.instance.Heal(health);
    }
    public override void Deactive()
    {
        Debug.Log("Deactive : "+ health);
    }    
}
