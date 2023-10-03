using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Power
{
    [HideInInspector]
    public PowerUp power;
    public float Duration;
    public Power(PowerUp power, float Duration)
    {

        this.power = power;
        this.Duration = 0;
    }
}
public class PowerManager : MonoBehaviour
{
    public List<Power> powers = new List<Power>();
    public static PowerManager instance;
    public System.Action<PowerUp> AddPowerUpAction;
    public System.Action<PowerUp> RemovePowerUpAction;
    public System.Action<PowerUp,float> UpdateTimer;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].Duration += Time.deltaTime;
            powers[i].Duration  = Mathf.Round(powers[i].Duration * 100.0f) * 0.01f;
            UpdateTimer?.Invoke(powers[i].power,powers[i].Duration);
            if(powers[i].Duration >= powers[i].power.Duration)
            {
                powers[i].power.Deactive();
                RemovePower(powers[i]);
            }
        }

    }
    public Power HasDuplicatePower(PowerUp powerUp)
    {
        foreach (Power power in powers)
        {
            if (power.power == powerUp)
            {
                return power; // พบ Power ที่มีอยู่แล้วใน List
            }
        }
        return null; // ไม่พบ Power ที่มีอยู่ใน List
    }
    public void AddPower(PowerUp powerup)
    {
        Power power = HasDuplicatePower(powerup);
        if(power != null)
            RemovePower(power);
        
        power = new Power(powerup,powerup.Duration);
        AddPowerUpAction?.Invoke(powerup);
        powerup.Active();
        powers.Add(power);
    }
    public void RemovePower(Power power)
    {

        RemovePowerUpAction?.Invoke(power.power);
        powers.Remove(power);
    }
}
