using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnEnemy : MonoBehaviour
{
    public GameObject _enemy;
    public int EnemyCount = 1;
    //Camera mainCamera;
    private float timer = 0f; // ตัวนับเวลา
    public float spawnTime = 1f; // 


    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(CreateNewEnemies());
    }

    IEnumerator CreateNewEnemies()
    {
        float multiplierLevel = WaveController.instance.multiplierLevel;
        for (int i = 0; i < EnemyCount; i++)
        {

            Vector2 min = CanMoveInScreen.instance.GetMinScreenPosition();
            Vector2 max = CanMoveInScreen.instance.GetMaxScreenPosition();
            Vector2 pos = new Vector2(Random.Range(min.x, max.x), max.y + _enemy.GetComponentInChildren<Renderer>().bounds.size.y / 2);
            Enemy Enemy = Instantiate(_enemy,pos, Quaternion.identity).GetComponent<Enemy>();
            Enemy.GetComponent<DirectMoving>().speed = Enemy.GetComponent<DirectMoving>().speed * multiplierLevel;
            Enemy.Damage = System.Convert.ToInt32(Enemy.Damage * multiplierLevel);
            Enemy.health = System.Convert.ToInt32(Enemy.health * multiplierLevel);
            yield return new WaitForSeconds(spawnTime);            
        }
        Destroy(gameObject);
    }

}
