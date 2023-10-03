using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PowerUp/PowerShield",fileName ="new PowerShield")]
public class PowerShield : PowerUp
{
    public override void Active()
    {
      Player.instance.OpenShield();
    }
    public override void Deactive()
    {
      Player.instance.CloseShield();
    }    
}
