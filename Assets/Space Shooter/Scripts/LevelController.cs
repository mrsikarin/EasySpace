using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    public GameObject[] powerUp;
    public float timeForNewPowerup;
    public GameObject[] planets;
    public float timeBetweenPlanets;
    public float planetsSpeed;
    List<GameObject> planetsList = new List<GameObject>();
    

    void Start()
    {
        GameStart();
    }
    public void GameStart()
    {
        StartCoroutine(PowerupBonusCreation());
        StartCoroutine(PlanetsCreation());
    }
    public void GameEnd()
    {
        StopAllCoroutines();
    }

    //endless coroutine generating 'levelUp' bonuses. 
    IEnumerator PowerupBonusCreation()
    {
        Vector2 posMin = CanMoveInScreen.instance.GetMinScreenPosition();
        Vector2 posMax = CanMoveInScreen.instance.GetMaxScreenPosition();
        while (true)
        {
            yield return new WaitForSeconds(timeForNewPowerup);
            int index = Random.Range(0, powerUp.Length);
            Instantiate(
                powerUp[index],
                //Set the position for the new bonus: for X-axis - random position between the borders of 'Player's' movement; for Y-axis - right above the upper screen border 
                new Vector2(
                    Random.Range(posMin.x, posMax.x),
                    posMax.y + powerUp[index].GetComponentInChildren<Renderer>().bounds.size.y / 2),
                Quaternion.identity
                );
        }
    }

    IEnumerator PlanetsCreation()
    {
        //Create a new list copying the arrey
        for (int i = 0; i < planets.Length; i++)
        {
            planetsList.Add(planets[i]);
        }
        yield return new WaitForSeconds(10);
        while (true)
        {
            int randomIndex = Random.Range(0, planetsList.Count);
            GameObject newPlanet = Instantiate(planetsList[randomIndex]);
            planetsList.RemoveAt(randomIndex);
            //if the list decreased to zero, reinstall it
            if (planetsList.Count == 0)
            {
                for (int i = 0; i < planets.Length; i++)
                {
                    planetsList.Add(planets[i]);
                }
            }
            newPlanet.GetComponent<DirectMoving>().speed = planetsSpeed;

            yield return new WaitForSeconds(timeBetweenPlanets);
        }
    }
}
