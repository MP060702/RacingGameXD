using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    
    public void EnemySpawn()
    {   
        if(Random.Range(0, 3) == 0)
        {
            Instantiate(Enemy, GameManager.Instance.Player().WayPoints.GetChild(GameManager.Instance.Player().WayIndex).position, Quaternion.identity); 
        }
    }
}
