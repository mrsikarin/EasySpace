using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PowerUp/PowerBullet",fileName ="new PowerBullet")]
public class PowerBullet : PowerUp
{
    public int Amount;
    public override void Active()
    {
        base.Active();
        PlayerShooting.instance.AddBullet(Amount);
    }
    public override void Deactive()
    {
        PlayerShooting.instance.SetBullet(1);
    }   
}
