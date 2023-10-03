
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerUpUI : MonoBehaviour
{
    public GameObject obj;
    public Dictionary<PowerUp,GameObject> powerIcon = new Dictionary<PowerUp,GameObject>();
    void Start()
    {
        PowerManager.instance.AddPowerUpAction += CreateIconPower;
        PowerManager.instance.RemovePowerUpAction += RemoveIconPower;
        PowerManager.instance.UpdateTimer += UpdateTimer;
    }
    public void UpdateTimer(PowerUp powerUp,float time)
    {
        GameObject powerObj = powerIcon[powerUp];
        float fillValue = time / powerUp.Duration;
        powerObj.transform.GetChild(0).GetComponent<Image>().fillAmount = fillValue;
    }
    public void CreateIconPower(PowerUp powerUp)
    {
        GameObject powerObj = Instantiate(obj,transform);
        powerObj.GetComponent<Image>().sprite = powerUp.Icon;
        powerIcon.Add(powerUp,powerObj);
    }
    public void RemoveIconPower(PowerUp powerUp)
    {
        GameObject powerObj = powerIcon[powerUp];
        powerIcon.Remove(powerUp);
        Destroy(powerObj);
    }
}
