using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject Heart;
    public List<GameObject> HealthGameObject;
    // Start is called before the first frame update
    void Start()
    {
        int health = Player.instance.GetHealth();
        HealthGameObject = new List<GameObject>();
        for (int i = 0; i < health; i++)
        {
            GameObject obj = Instantiate(Heart,transform);
            HealthGameObject.Add(obj);
        }
    }

    void Update()
    {
        int health = Player.instance.GetHealth();
        for (int i = 0; i < HealthGameObject.Count; i++)
        {
            if(health > i)
                HealthGameObject[i].transform.GetChild(0).gameObject.SetActive(true);
            else
                HealthGameObject[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
